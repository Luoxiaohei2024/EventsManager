using CommandSystem;
using EventsManager;
using EventsManager.Interfaces;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManager.command
{
    [CommandHandler(typeof(Main))]
    public class Run : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            IEvent testEvent = Manager.events.FirstOrDefault(e => e.EventName == arguments.At(0));

            if (testEvent != null) 
            { 
                if(Manager.@event != null)
                {
                    Manager.@event.StopEvent();
                }
                if (arguments.Count >1  && arguments.At(1) == "false")
                {
                    testEvent.PrepareEvent();
                    Manager.@event = testEvent;
                }
                else
                {
                    Manager.@event = testEvent;
                    Round.Restart();
                }

            }
            else
            {
                response = $"未找到 EventName 为 '{string.Join(" ", arguments)}' 的事件。";
                return true;
            }
            response = "run "+ string.Join(" ", arguments);
            return true;
        }

        public string Command { get; } = "Run";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "启动小游戏";
    }
}
