using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{
    public class Day1
    {
        public static void Calculate()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            int previous = -1;
            Dictionary<string, int> depthChanges = new()
            {
                { "increase", 0 },
                { "decrease", 0 }
            };
            string[] values = InputDay1.values.Split('\n');
            foreach (string depth in values)
            {
                int iDepth = int.Parse(depth);
                if (previous == -1)
                {
                    previous = iDepth;
                }
                else
                {
                    if (iDepth > previous)
                    {
                        depthChanges["increase"]++;
                        previous = iDepth;
                    }
                    else
                    {
                        depthChanges["decrease"]++;
                        previous = iDepth;
                    }
                }
            }

            watch.Stop();
            Console.WriteLine($"{depthChanges["increase"]} increases. Found in {watch.Elapsed} milliseconds.");
        }
    }
}
