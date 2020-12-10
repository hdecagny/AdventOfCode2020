using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day7\Data.txt")
                .ToList();

            var dataInDictionnary = ConvertData(data);

            var result1 = SolvePuzzle1(dataInDictionnary);
            var result2 = SolvePuzzle2(dataInDictionnary);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        private static Dictionary<string, Dictionary<string, int>> ConvertData(List<string> input)
        {
            var result = new Dictionary<string, Dictionary<string, int>>();

            foreach (var line in input)
            {
                AddDictionnaryEntry(result, line);
            }


            return result;
        }

        private static void AddDictionnaryEntry(Dictionary<string, Dictionary<string, int>> currentDictionnary, string input)
        {
            var bagcolor = input.Split(" bags contain ")[0];
            var contents = input
                .Split(" bags contain ")[1]
                .Replace("no other bags", "")
                .Replace("bags", "")
                .Replace("bag", "")
                .Replace(" .", "")
                .Split(" , ");

            if (contents[0].Length > 2)
            {
                var dictionnarycontent = contents.ToDictionary(content => content.Substring(2), content => (int) char.GetNumericValue(content[0]));


                currentDictionnary.Add(bagcolor, dictionnarycontent);
            }

            else
            {
                currentDictionnary.Add(bagcolor, new Dictionary<string, int>());
            }
        }

        private static int SolvePuzzle1(Dictionary<string, Dictionary<string, int>> input)
        {
            var result = 0;


            foreach (var bagcolor in input)
            {
                var queue = new Queue<string>();

                foreach (var color in bagcolor.Value.Keys)
                {
                    queue.Enqueue(color);
                }

                while (queue.Count > 0)
                {
                    var nextColor = queue.Dequeue();

                    if (nextColor == "shiny gold")
                    {
                        result += 1;
                        break;
                    }

                    var colorinbags = input[nextColor].Keys;

                    foreach (var color in colorinbags)
                    {
                        queue.Enqueue(color);
                    }
                }
            }

            return result;
        }

        private static int SolvePuzzle2(Dictionary<string, Dictionary<string, int>> input)
        {
            var queue = new Queue<KeyValuePair<string, int>>();
            var result = 0; //(the original shiny bag)

            foreach (var color in input["shiny gold"])
            {
                queue.Enqueue(color);
            }

            while (queue.Count > 0)
            {
                var nextbagcolor = queue.Dequeue();
                result += nextbagcolor.Value;

                var colorinbags = input[nextbagcolor.Key];

                foreach (var color in colorinbags)
                {
                    queue.Enqueue(new KeyValuePair<string, int>(color.Key, color.Value * nextbagcolor.Value));
                }



            }

            return result;
        }
    }
}