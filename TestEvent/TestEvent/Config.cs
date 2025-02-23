using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvent
{
    public class Config
    {
        [Description("是否自动运行")]
        public bool AutoRun { get; set; } = true;
    }
}
