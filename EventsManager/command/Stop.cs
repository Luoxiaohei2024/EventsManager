using CommandSystem;
using EventsManager.Interfaces;
using LabApi.Features.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManager.command
{
    [CommandHandler(typeof(Main))]
    public class Stop : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(Manager.@event==null)
            {
                response = "当前没有正在运行的小游戏";
                return false;
            }

            Manager.@event.StopEvent();
            response = $"OK,已停止 {Manager.@event.EventName}";

            Manager.@event = null;

            if(arguments.Count>0 && arguments.At(0) == "true") 
            {
                Round.Restart();
            }
            return true;
        }

        public string Command { get; } = "Stop";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "停止当前运行中的小游戏";
    }
}
