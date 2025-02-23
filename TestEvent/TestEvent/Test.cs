using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsManager.Interfaces;
using LabApi.Features.Console;
using EventsManager;
using LabApi.Loader.Features.Plugins;

namespace TestEvent
{
    public class Test:IEvent
    {
        public  string EventName { get; } = "test";
        public string EvenAuthor { get; } = "罗小黑";
        public string EventDescription { get; set; } = "测试插件"; 
        public static Test Singleton { get; private set; }
        public void PrepareEvent()
        {
            TestEvent.Run();
            Logger.Debug("事件运行");
        }
        public void StopEvent()
        {
            TestEvent.Stop();
            Logger.Debug("事件停止");
        }
    }
}
