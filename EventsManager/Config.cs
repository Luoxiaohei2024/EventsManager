using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace EventsManager
{
   public class Config
    {
        [Description("是否自动运行")]
        public bool AutoRun { get; set; } = true; 
    }
}
