using EventsManager.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApi.Events.Arguments;
using LabApi.Events.Handlers;
using LabApi.Features.Wrappers;

namespace TestEvent
{
    public class TestEvent
    {
        public static void Run()
        {
            PlayerEvents.Joined += Joined;
        }
        public static void Stop()
        {
            PlayerEvents.Joined -= Joined;
        }

        private static void Joined(LabApi.Events.Arguments.PlayerEvents.PlayerJoinedEventArgs ev)
        {
            ev.Player.SendBroadcast("Test", 30, 0, true);
        }



    }
}
