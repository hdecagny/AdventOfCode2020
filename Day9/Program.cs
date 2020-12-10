using System;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day9\Data.txt")
                .Select(Int64.Parse)
                .ToList();

            var result1 = SolvePuzzle1(data);
            var result2 = SolvePuzzle2(data, result1);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public static long SolvePuzzle1(List<long> input)
        {
            const int sizeSubArray = 25;
            var maxindex = input.Count - 1;

            for (var i = sizeSubArray; i <= maxindex; i++)
            {
                if (!DoesSumExist(input.GetRange(i - sizeSubArray, sizeSubArray), input[i]))
                {
                    return input[i];
                }
            }

            return -100;
        }

        public static long SolvePuzzle2(List<long> input, long result)
        {
            var maxindex = input.Count - 1;

            for (var i = 0; i <= maxindex; i++)
            {
                long sum = 0;
                var j = 0;

                while (sum < result)
                {
                    sum += input[i + j];

                    if (sum == result)
                    {
                        var sublist = input.GetRange(i, j+1);
                        return sublist.Max() + sublist.Min();
                    }

                    j++;
                }
            }

            return -100;
        }

        public static bool DoesSumExist(List<long> input, long result)
        {
            return input.Any(i => (i != result / 2) && input.Contains(result - i));
        }
    }
}