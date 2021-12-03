using AoC1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{
    public class Day3
    {
        public static void Calculate()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            string gamma = String.Empty;
            string epsilon = String.Empty;
            string[] data = InputDay3.values.Split("\r\n");
            Dictionary<int, BitTally> results = new()
            {
                { 0, new BitTally() },
                { 1, new BitTally() },
                { 2, new BitTally() },
                { 3, new BitTally() },
                { 4, new BitTally() },
                { 5, new BitTally() },
                { 6, new BitTally() },
                { 7, new BitTally() },
                { 8, new BitTally() },
                { 9, new BitTally() },
                { 10, new BitTally() },
                { 11, new BitTally() },
            };

            foreach(string line in data)
            {
                for(int i = 0; i< 12; i++)
                {
                    BitTally tally = results[i];
                    if(line[i] == '0')
                    {
                        tally.Zeros++;
                    }
                    else
                    {
                        tally.Ones++;
                    }
                }
            }

            foreach(KeyValuePair<int, BitTally> kv in results)
            {
                if(kv.Value.Zeros > kv.Value.Ones)
                {
                    gamma = gamma + "1";
                    epsilon = epsilon + "0";
                }
                else
                {
                    gamma = gamma + "0";
                    epsilon = epsilon + "1";
                }

            }
            int iGamma = Convert.ToInt32(gamma, 2);
            int iEpsilon = Convert.ToInt32(epsilon, 2);
            watch.Stop();
            Console.WriteLine($"Power consupmtion is {iGamma * iEpsilon}. Found in {watch.Elapsed}.");
        }
    }

    class BitTally
    {
        public int Zeros { get; set; } = 0;
        public int Ones { get; set; } = 0;
    }
}
