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
    public class Reload : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Manager.events.Clear();
            Manager.LoadEvent();
            response = "OK";
             if(arguments.Count>0 && arguments.At(0) == "true") 
            {
                Round.Restart();
            }
            return true;
        }

        public string Command { get; } = "Reload";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "重载小游戏资源";
    }
}
