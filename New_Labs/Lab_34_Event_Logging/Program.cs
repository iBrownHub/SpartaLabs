using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_34_Event_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog.WriteEntry("Application", "Llow it", EventLogEntryType.Warning, 5001, 1239);
        }
    }
}
