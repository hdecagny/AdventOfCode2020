using System;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File
                    .ReadAllText(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day6\Data.txt")
                    .Split("\r\n\r\n").ToList()
                ;

            var result = data.Select(CountQuestions).Sum();

            var result2 = data.Select(CountQuestionsPart2).Sum();

            Console.WriteLine(result);
            Console.WriteLine(result2);
        }

        public static int CountQuestions(string input)
        {
            return input.Replace("\r", "").Replace("\n", "").Distinct().Count();
        }

        public static int CountQuestionsPart2(string input)
        {
            var individualFormularyList = input.Split("\r\n").ToList();

            var commonQuestions = individualFormularyList[0];

            foreach (var formulary in individualFormularyList)
            {
                commonQuestions = string.Concat(commonQuestions.Intersect(formulary));
            }

            return commonQuestions.Distinct().Count();
        }
    }
}
