using AoC1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{

    public class Day2
    {
        public static void Calculate()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            string[] values = InputDay2.values.Split("\r\n");
            int xPos = 0;
            int yPos = 0;

            foreach(string movement in values)
            {
                string[] data = movement.Split(" ");
                int distance = int.Parse(data[1]);
                switch (data[0])
                {
                    case "forward":
                        xPos += distance;
                        break;
                    case "down":
                        yPos += distance;
                        break;
                    default:
                        yPos -= distance;
                        break;
                }
            }
            watch.Stop();
            Console.WriteLine($"{xPos * yPos} found in {watch.Elapsed} ms");
        }
    }
}
