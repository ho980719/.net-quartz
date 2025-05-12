using System;
using System.Net.Http;
using System.Threading.Tasks;
using Quartz;

namespace Quarz_Test.Quartz.Job
{
    public class JobTest : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            string url = "https://postman-echo.com/get?foo=bar&baz=value";  // 여기에 호출할 API 주소를 입력

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    string content = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"[{DateTime.Now}] 응답 코드: {response.StatusCode}, 내용: {content}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{DateTime.Now}] API 호출 실패: {ex.Message}");
                }
            }
        }
    }
}