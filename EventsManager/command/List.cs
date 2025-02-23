using CommandSystem;
using EventsManager.Interfaces;
using System;

namespace EventsManager.command
{
    [CommandHandler(typeof(Main))]
    public class List : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string li = "";
            foreach (IEvent ev in Manager.events)
            {
                li += ev.EventName + "\n";
            }
            response = li;
            return true;
        }

        public string Command { get; } = "List";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "查看可启动的小游戏列表";
    }
}
