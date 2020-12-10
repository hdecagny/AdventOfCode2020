using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day8\Data.txt")
                .Select(s=>s.Split(" "))
                .ToList();

            var consoleExecutor = new ConsoleExecutor();

            var result1 = consoleExecutor.FindValueAccumulator(data);
            Console.WriteLine(result1);

            var result2 = consoleExecutor.RepairProgram(data);
            Console.WriteLine(result2);
        }
    }
}
