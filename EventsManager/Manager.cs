using EventsManager.Interfaces;
using LabApi.Events;
using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.Handlers;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader;
using LabApi.Loader.Features.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventsManager
{
    public class Manager : Plugin
    {
        public override string Name { get; } = "EventsManager";

        public override string Description { get; } = "小游戏管理器";

        public override string Author { get; } = "罗小黑";
        public override Version Version { get; } = new Version(1, 0, 0, 0);

        public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);
        public static Config Config; public 
       static DirectoryInfo Event { get; }
        public static Manager Instance { get; private set; }
        public override void LoadConfigs()
        {
            base.LoadConfigs();

            Config = this.LoadConfig<Config>("Config.yml");
        }

        public static string EventsPath
        {
            get
            {
                string path = LabApi.Loader.Features.Paths.PathManager.Configs.FullName + "/EventsManager/Events";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public static List<IEvent> events { set; get; } = new List<IEvent>();
        public static IEvent @event = null;
        public static void LoadEvent()
        {
            string[] dllFiles = Directory.GetFiles(EventsPath, "*.dll");
            foreach (string dllFile in dllFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (typeof(IEvent).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        {
                            IEvent eventInstance = (IEvent)Activator.CreateInstance(type);
                            events.Add(eventInstance);

                            Logger.Info(eventInstance.EventName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"加载 {dllFile} 时发生错误: {ex.Message}");
                }
            }
        }
        public override void Enable()
        {
            Instance = this;
            LoadEvent();

            if (Config.AutoRun == true) 
            { 
            ServerEvents.WaitingForPlayers += AutoRunEvent; 
            }

            ServerEvents.RoundEnded += StopEvent;
        }
        public void AutoRunEvent()
        {
            if (@event != null)
            {
                @event.PrepareEvent();
                return;
            }
            if (events.Count == 0)
            {
                return;
            }

            Random random = new Random();
            int randomIndex = random.Next(0, events.Count);

            events[randomIndex].PrepareEvent();
            @event = events[randomIndex];

        }
        public void StopEvent(RoundEndedEventArgs ev)
        {
            if (@event != null)
            {
                @event.StopEvent();
            }


        }
        public override void Disable()
        {

        }
    }
}
