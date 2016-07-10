using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFileSplit
{
    public class Arguments
    {
        private List<string> _args;

        public Arguments(IEnumerable<string> args)
        {
            _args = new List<string>(args);
        }

        public bool ContainsSwtich(string name)
        {
            return _args.Contains(name);
        }

        private string GetSwitchValue(string name)
        {
            return GetSwitchValue<string>(name, null);
        }

        private T GetSwitchValue<T>(string name, T defaultVal)
        {
            if (!ContainsSwtich(name)) return defaultVal;
            var item = _args.First(i => i == name);
            var itemIndex = _args.IndexOf(item);
            if ((itemIndex + 1) > _args.Count) return defaultVal;
            return (T)Convert.ChangeType(_args[itemIndex + 1], typeof(T));
        }

        public void PrintHelp()
        {
            const string help = @"
--help: prints this help guide
--file: the name of the file to work on
--output: the name of the file to generate
--start: the line number to start on
--end: the line number to end on
";
            Console.WriteLine(help);
        }

        public string File { get { return GetSwitchValue("--file"); } }
        public string Outout { get { return GetSwitchValue("--output"); } }
        public long Start { get { return GetSwitchValue("--start", 0L); } }
        public long End { get { return GetSwitchValue("--end", 0L); } }

    }
}
