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

            var rowSeatPairList = data.Select(ConvertToNumbers).ToList(); //Converting those data into lists of two numbers : row and seat

            var result1 = SolvePuzzle1(rowSeatPairList);

            var result2 = SolvePuzzle2(rowSeatPairList);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public static int[] ConvertToNumbers(string input)
        {
            var binaryInput = input.Replace('B', '1')
                                          .Replace('F', '0')
                                          .Replace('L','0')
                                          .Replace('R','1');

            var binaryRow = binaryInput.Substring(0, 7);
            var binarySeat = binaryInput.Substring(7, 3);

            var rowNumber = Convert.ToInt32(binaryRow, 2);
            var seatNumber = Convert.ToInt32(binarySeat, 2);

            return new []{ rowNumber  , seatNumber };

        }

        public static int SolvePuzzle1(IList<int[]> input)
        {
            return input.Select(pair => pair[0] * 8 + pair[1]).Max();
        }

        public static int SolvePuzzle2(IList<int[]> input) 
        {
            var ticketsForIncompleteRow = input.GroupBy(i => i[0])
                .First(i => i.Count<int[]>() == 7); //All the complete rows should have 8 tickets

            var missingRow = ticketsForIncompleteRow.Key;
            var incompleteSeat = 7 * 8 / 2 - ticketsForIncompleteRow.Select(i => i[1]).ToList().Sum(); // 0+1+..+8 = 7*8/2 If I sum all the tickets I have, I should arrive to the missing one

            return missingRow * 8 + incompleteSeat;

        }
    }
}
