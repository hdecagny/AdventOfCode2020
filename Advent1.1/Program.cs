using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Advent1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Advent1.1\data.txt")
                .Select(int.Parse)
                .ToList();

            var result1 = data.First(i => data.Contains(2020 - i));

            var test = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Advent1.1\data.txt")
                .ToList();


            Console.WriteLine(result1 * (2020 - result1));

            //Second part (non elegant)

            foreach (var i in data)
            {
                foreach (var j in data)
                {
                    foreach (var k in data.Where(k => i+j+k == 2020))
                    {
                        Console.WriteLine(i*j*k);
                        break;
                    }
                }
            }
            

        }
    }
}