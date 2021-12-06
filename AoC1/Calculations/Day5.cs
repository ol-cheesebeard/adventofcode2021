using AoC1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{
    public class Day5
    {
        private static int[,] coordinates = new int[999, 999];
        public static void Calculate()
        {
            string[] input = InputDay5.values.Split("\r\n");
            parseInput(input);
            int finalCount = 0;
            foreach(int val in coordinates)
            {
                if (val > 1) finalCount++;
            }
            Console.WriteLine(finalCount);
        }

        private static void parseInput(string[] input)
        {
            foreach (string s in input)
            {
                string[] split = s.Split(" -> ");
                string[] startCoords = split[0].Split(',');
                string[] endCoords = split[1].Split(',');
                Point start = new Point(startCoords[0], startCoords[1]);
                Point end = new Point(endCoords[0], endCoords[1]);

                if (start.x == end.x || start.y == end.y)
                {
                    getMovements(start, end);
                }
            }
        }

        private static void getMovements(Point start, Point end)
        {
            if(start.x == end.x) //vertical movement
            {
                if(start.y <= end.y)
                {
                    int tempY = end.y;
                    while(start.y <= tempY)
                    {
                        coordinates[start.x, tempY]++;
                        tempY--;
                    }
                }
                else
                {
                    int tempY = end.y;
                    while (start.y >= tempY)
                    {
                        coordinates[start.x, tempY]++;
                        tempY++;
                    }
                }
            }
            else
            {
                if (start.x <= end.x)
                {
                    int tempX = end.x;
                    while (start.x <= tempX)
                    {
                        coordinates[tempX, start.y]++;
                        tempX--;
                    }
                }
                else
                {
                    int tempX = end.x;
                    while (start.x >= tempX)
                    {
                        coordinates[tempX, start.y]++;
                        tempX++;
                    }
                }
            }
        }
    }

    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        
        public Point(string x, string y)
        {
            this.x = int.Parse(x);
            this.y = int.Parse(y);
        }
    }
}
