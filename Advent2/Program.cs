using System;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Advent2\Data.txt")
                .ToList();

            var result1 = data.Count(s => new PasswordVerificator(s).IsValidPart1());

            Console.WriteLine(result1);

            var result2 = data.Count(s => new PasswordVerificator(s).IsValidPart2());

            Console.WriteLine(result2);

        }
    }
}
