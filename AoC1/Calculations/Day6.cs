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

        public static void Calculate()
        {
            List<int> fish = InputDay6.values.Split(",").Select(x => int.Parse(x)).ToList();
            Dictionary<int, double> countCache = CreateCache();
            Dictionary<int, double> changeCache = CreateCache();

            for (int j = 0; j < fish.Count; j++)
            {
                int value = fish[j];
                countCache[value]++; 
            }
            for(int i = 0; i < 256; i++)
            {
                for(int j = 8; j >= 0; j--)
                {
                    if(j > 0)
                    {
                        double currentValue = countCache[j] - changeCache[j];
                        countCache[j] -= currentValue;
                        countCache[j-1] += currentValue;
                        changeCache[j - 1] = currentValue;

                    }
                    else
                    {
                        double currentValue = countCache[j] - changeCache[j];
                        countCache[j] -= currentValue;
                        countCache[6] += currentValue;
                        countCache[8] += currentValue;
                        changeCache = CreateCache();
                    }
                }
            }
            double sum = 0;
            foreach(KeyValuePair<int, double> kv in countCache)
            {
                sum += kv.Value;
            }
            Console.WriteLine($"there are { sum } lantern fish");
        }

        public static Dictionary<int, double> CreateCache()
        {
            return new Dictionary<int, double>
            {
                { 0, 0 },
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 },
            };
        }
    }
}
