using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFileSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new Arguments(args);
            if(args.Length <= 2 || arguments.ContainsSwtich("--help"))
            {
                arguments.PrintHelp();
                return;
            }
            var split = new FileSplit(arguments);
            split.DoSplit();
        }
    }
}
