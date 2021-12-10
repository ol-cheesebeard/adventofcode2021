using AoC1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{
    public class Day7
    {
        public static void Calculate()
        {
            List<int> initialState = InputDay7.values.Split(",").Select(x => int.Parse(x)).ToList();
            Dictionary<int, int> fuelSpentDict = new Dictionary<int, int>();
            for(int i = 0; i < initialState.Count; i++)
            {
                fuelSpentDict.Add(i, 0);
            }
            for(int i = 0; i < initialState.Count; i++)
            {
                for(int j = 0; j < initialState.Count; j++)
                {
                    int value = initialState[j];
                    int fuelSpent = Math.Abs(value - i);
                    fuelSpentDict[i] += fuelSpent;
                }
            }
            var min = fuelSpentDict.OrderBy(x => x.Value).First();
            Console.WriteLine($"The minimum value is {min}");
        }

        public static void Part2()
        {
            List<int> initialState = InputDay7.values.Split(",").Select(x => int.Parse(x)).ToList();
            Dictionary<int, int> fuelSpentDict = new Dictionary<int, int>();
            for (int i = 0; i < initialState.Count; i++)
            {
                fuelSpentDict.Add(i, 0);
            }
            for (int i = 0; i < initialState.Count; i++)
            {
                for (int j = 0; j < initialState.Count; j++)
                {
                    int value = initialState[j];
                    int fuelStep = 1;
                    int fuelSpent = 0;
                    while(value != i)
                    {
                        fuelSpent += fuelStep;
                        if (value > i) value--;
                        else value++;
                        fuelStep++;
                    }

                    fuelSpentDict[i] += fuelSpent;
                }
            }
            var min = fuelSpentDict.OrderBy(x => x.Value).First();
            Console.WriteLine($"The minimum value is {min} in pt2");
        }
    }
}
