using Quartz;
using Quartz.Impl;
using Quarz_Test.Quartz.Job;

public class QuartzService
{
    private readonly IScheduler _scheduler;

    public QuartzService()
    {
        // 스케줄러 초기화
        _scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
    }

    public void Start()
    {
        // 스케줄러 시작
        _scheduler.Start();
    }

    public void Stop()
    {
        // 스케줄러 종료
        _scheduler.Shutdown();
    }

    public void ConfigureJobs()
    {
        // Job 정의
        IJobDetail job = JobBuilder.Create<JobTest>()
            .WithIdentity("myJob", "group1")
            .Build();

        // Trigger 정의 (5초 간격)
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("myTrigger", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(5)
                .RepeatForever())
            .Build();

        // Job과 Trigger를 스케줄러에 등록
        _scheduler.ScheduleJob(job, trigger);
    }
}