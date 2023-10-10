using log4net;
using log4net.Config;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace 定时任务.Job
{
    public class MyJob : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MyJob));
        public async Task Execute(IJobExecutionContext context)
        {
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            new FileInfo(configFilePath);
            // 执行定时任务的逻辑
            // 可以在这里编写需要定期执行的代码
            log.Info("定时任务开始执行");

            log.Info($"当前时间:{DateTime.Now}");
            // 执行定时任务的逻辑
            // ...

            log.Info("定时任务执行完毕");
        }
    }
}