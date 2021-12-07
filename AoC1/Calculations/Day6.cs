using AoC1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{
    public class Day6
    {
        //private List<int> initialFish = InputDay6.values.Split(",").Select(x => int.Parse(x)).ToList();

        public static void Calculate()
        {
            List<int> fish = InputDay6.values.Split(",").Select(x => int.Parse(x)).ToList();

            for(int i = 0; i < 80; i++)
            {
                int count = fish.Count;
                for(int j = 0; j < count; j++)
                {
                    if (fish[j] == 0)
                    {
                        fish[j] = 6;
                        fish.Add(8);
                    }
                    else
                    {
                        fish[j]--;
                    }
                }
            }
            Console.WriteLine($"there are {fish.Count} lantern fish");
        }
    }
}
