using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFileSplit
{
    public class FileSplit
    {
        public FileSplit(Arguments args)
        {
            Args = args;
        }

        public Arguments Args { get; private set; }

        public void DoSplit()
        {
            Console.WriteLine("Starting");
            Console.WriteLine();
            var counter = 0L;
            var byteCount = 0L;
            using (var reader = new StreamReader(Args.File))
            {
                using (var writer = new StreamWriter(Args.Outout))
                {
                    while (!reader.EndOfStream || (Args.End > 0 && (counter > Args.End)))
                    {
                        var line = reader.ReadLine();
                        byteCount += line.Length;
                        if (counter >= Args.Start)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        Console.Write("\rProcesing line {0} Progress {1} ", counter, GetProgress(byteCount, reader.BaseStream.Length));
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Completed");
        }

        public string GetProgress(long byteCount, long total)
        {
            return (((double)byteCount / (double)total)*100).ToString("N2") + "%";
        }
    }
}
