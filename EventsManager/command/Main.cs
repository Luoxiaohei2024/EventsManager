using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManager.command
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Main : ParentCommand
    {
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Please enter a valid subcommand: \n";
            foreach (var x in this.Commands)
            {
                string args = "";
                if (x.Value is IUsageProvider usage)
                {
                    foreach (string arg in usage.Usage)
                    {
                        args += $"[{arg}] ";
                    }
                }
               


                if (sender is not ServerConsoleSender)
                    response += $"<color=yellow> {x.Key} {args}<color=white>-> {x.Value.Description}. \n";
                else
                    response += $" {x.Key} {args} -> {x.Value.Description}. \n";
            }
            return false;
        }
        public override void LoadGeneratedCommands()
        {
        }
        public override string Command { get; } = "ev";
        public override string[] Aliases { get; } = Array.Empty<string>();
        public override string Description { get; } = "小游戏主指令";
    }
}
