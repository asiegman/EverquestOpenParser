using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenParser.EventResults
{
    public class Who : EventResult
    {
        public Who(LogEntry entry, string name, string guild, string zone) : base(entry)
        {
            Name = name;
            Guild = guild;
            Zone = zone;
        }

        public string Name { get; }
        public string Guild { get; }
        public string Zone { get; }
    }
}