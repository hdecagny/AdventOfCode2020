using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day3\Data.txt")
                .ToList();

            var result1 = HowManyTreesOnTheWay(data, 3, 1);

            Console.WriteLine(result1);

            long result2 =
                HowManyTreesOnTheWay(data, 1, 1) *
                HowManyTreesOnTheWay(data, 3, 1) *
                HowManyTreesOnTheWay(data, 5, 1) *
                HowManyTreesOnTheWay(data, 7, 1) *
                HowManyTreesOnTheWay(data, 1, 2);

            Console.WriteLine(result2);
        }


        public static long HowManyTreesOnTheWay(IReadOnlyList<string> slope, int angle, int speed)
        {
            var length = slope[0].Length;
            var height = slope.Count;
            var result = 0;

            for (var currentHeight = 0; currentHeight < height; currentHeight += speed)
            {
                var position = (currentHeight * angle / speed) % length;

                if (slope[currentHeight][position] == '#')
                {
                    result += 1;
                }
            }

            return result;
        }
    }
}