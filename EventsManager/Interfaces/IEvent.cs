using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsManager;
namespace EventsManager.Interfaces
{
    public interface IEvent
    {
        string EventName { get; }
        string EvenAuthor { get; }
        string EventDescription { get; set; }

        void PrepareEvent();
        void StopEvent();
    }
}
