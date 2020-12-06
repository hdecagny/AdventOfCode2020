using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day5\Data.txt")
                .ToList();
            var iDList = data.Select(ConvertToID).ToList();

            var result1bis = SolvePuzzle1(iDList);

            var result2bis = SolvePuzzle2(iDList);


            Console.WriteLine(result1bis);
            Console.WriteLine(result2bis);
        }

        public static int ConvertToID(string input)
        {
            var binaryInput = input.Replace('B', '1')
                .Replace('F', '0')
                .Replace('L', '0')
                .Replace('R', '1');

            var binaryRow = binaryInput.Substring(0, 7);
            var binarySeat = binaryInput.Substring(7, 3);

            var rowNumber = Convert.ToInt32(binaryRow, 2);
            var seatNumber = Convert.ToInt32(binarySeat, 2);

            return rowNumber * 8 + seatNumber;
        }

        public static int SolvePuzzle1(IList<int> input)
        {
            return input.Max();
        }

        public static int SolvePuzzle2(IList<int> input)
        {
            var iDmin = input.Min();
            var iDMax = input.Max();

            var result = (iDMax * (iDMax + 1) - iDmin * (iDmin - 1)) / 2 - input.Sum();

            return result;
        }


    }
}