using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllText(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day4\Data.txt");

            var passports = data.Split("\r\n\r\n");
            var passports2 = passports.Select(p => p.Replace("\r\n", " ")).ToList();
            var passportsWithFields = passports2.Select(p => p.Split(' ')).ToList();

            var validfields = new List<string>
            {
                "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
            };

            var result = passportsWithFields.Count(f => IsPassportValidPart1(f, validfields));

            var test = IsPassportValidPart2(passportsWithFields[0], validfields);

            Console.WriteLine(result);

        }

        private static bool IsPassportValidPart1(IEnumerable<string> passport, IReadOnlyCollection<string> validfields)
        {
            var fields = passport.Select(f => f.Split(":")[0]).ToList();

            var intersect = fields.Intersect(validfields).ToList();

            return intersect.Count()==validfields.Count();

        }

        private static bool IsPassportValidPart2(IEnumerable<string> passport, IReadOnlyCollection<string> validfields)
        {
            var fields = passport.Select(f => f.Split(":")).ToDictionary(f=>f[0], f=>f[1]);


            return true;

        }
    }
}
