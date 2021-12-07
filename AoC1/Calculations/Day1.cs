using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{
    public class Day1
    {
        private static List<int> values = InputDay1.values.Split('\n').Select(x => int.Parse(x)).ToList();
        public static void Calculate()
        {
            int previous = -1;
            Dictionary<string, int> depthChanges = new()
            {
                { "increase", 0 },
                { "decrease", 0 }
            };

            foreach (int depth in values)
            {
                if (previous == -1)
                {
                    previous = depth;
                }
                else
                {
                    if (depth > previous)
                    {
                        depthChanges["increase"]++;
                        previous = depth;
                    }
                    else
                    {
                        depthChanges["decrease"]++;
                        previous = depth;
                    }
                }
            }
            Console.WriteLine($"{depthChanges["increase"]} increases.");
        }

        public static void Part2()
        {
            Dictionary<int, int> slidingWindow1;
            Dictionary<int, int> slidingWindow2;
            Dictionary<string, int> depthChangesPt2 = new()
            {
                { "increase", 0 },
                { "decrease", 0 }
            };

            for (int i = 0; i < values.Count; i++)
            {
                try
                {
                    slidingWindow1 = CreateWindow(values[i], values[i + 1], values[i + 2]);
                    slidingWindow2 = CreateWindow(values[i + 1], values[i + 2], values[i + 3]);
                }
                catch (Exception ex)
                {
                    break;
                }
                if (slidingWindow1 != null && slidingWindow2 != null)
                {
                    if(GetSum(slidingWindow2) > GetSum(slidingWindow1))
                    {
                        depthChangesPt2["increase"]++;
                    }
                    else
                    {
                        depthChangesPt2["decrease"]++;
                    }
                }
            }
            Console.WriteLine($"{depthChangesPt2["increase"]} increases in pt2.");
        }
        public static Dictionary<int,int> CreateWindow(int first, int second, int third)
        {
            try
            {
                Dictionary<int, int> window = new()
                {
                    { 1, first },
                    { 2, second },
                    { 3, third },
                };
                return window;
            }catch(Exception ex)
            {
                return null;
            }

        }

        public static int GetSum(Dictionary<int, int> window)
        {
            return window[1] + window[2] + window[3];
        }
    }

    class SlidingWindow
    {
        public Dictionary<int, int> MyProperty { get; set; }
    }
}
