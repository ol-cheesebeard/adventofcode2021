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
        private static string[] values = InputDay2.values.Split("\r\n");
        public static void Calculate()
        {
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
            Console.WriteLine($"{xPos * yPos} found");
        }

        public static void Part2()
        {
            int aim = 0;
            int xPos = 0;
            int depth = 0;


            foreach (string movement in values)
            {
                string[] data = movement.Split(" ");
                int distance = int.Parse(data[1]);
                switch (data[0])
                {
                    case "forward":
                        

                        xPos += distance;
                        depth += distance * aim;
                        break;
                    case "down":
                        aim +=distance;
                        break;
                    default:
                        aim -= distance;
                        break;
                }
            }
            Console.WriteLine($"{xPos * depth} found");
        }
    }
}
