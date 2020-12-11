using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day10\Data.txt")
                .Select(int.Parse)
                .ToList();

            data.Sort();

            var result1 = SolvePuzzle1(data);
            Console.WriteLine(result1);

            var result2 = SolvePuzzle2(data);
            Console.WriteLine(result2);
        }

        public static int SolvePuzzle1(List<int> data)
        {
            var diff1 = 0;
            var diff3 = 0;

            var currentJoltage = 0;

            foreach (var adapter in data)
            {
                switch (adapter - currentJoltage)
                {
                    case (1):
                        diff1++;
                        break;
                    case 2:
                        break;
                    case 3:
                        diff3++;
                        break;
                    default:
                        throw new ArgumentException();
                }

                currentJoltage = adapter;
            }

            diff3++;

            return diff1 * diff3;
        }

        public static long SolvePuzzle2(List<int> data)
        {
            var numberOfCombinationToReachGivenVoltage = new Dictionary<int, long> {{0, 1}, {-1, 0}, {-2, 0}};

            foreach (var adapter in data)
            {
                var numberCombiJoltageMinus1 = numberOfCombinationToReachGivenVoltage.ContainsKey(adapter - 1) ? numberOfCombinationToReachGivenVoltage[adapter - 1] : 0;
                var numberCombiJoltageMinus2 = numberOfCombinationToReachGivenVoltage.ContainsKey(adapter - 2) ? numberOfCombinationToReachGivenVoltage[adapter - 2] : 0;
                var numberCombiJoltageMinus3 = numberOfCombinationToReachGivenVoltage.ContainsKey(adapter - 3) ? numberOfCombinationToReachGivenVoltage[adapter - 3] : 0;

                var numberofCombination = numberCombiJoltageMinus1 + numberCombiJoltageMinus2 + numberCombiJoltageMinus3;

                numberOfCombinationToReachGivenVoltage.Add(adapter,numberofCombination);
            }

            var last = data.Last();
            return numberOfCombinationToReachGivenVoltage[last];
        }
    }
}