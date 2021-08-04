using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace process_note.ViewModels
{
    public class WindowsProcess
    {
        public int Id { get; set; }
        public String ProcessName { get; set; }
        public int VirtualMemorySize { get; set; }
        public String CPUTime { get; set; }
        public String StartTime { get; set; }
        public String RunningTime { get; set; }
    }
}
