using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var data = System.IO.File
                .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day10\Data.txt")
                .ToList();

            var result1 = SolvePuzzle1(data);
            Console.WriteLine(result1);
        }

        public static int SolvePuzzle1(List<string> input)
        {
            var heigth = input.Count();
            var length = input[0].Length;
            var isStable = false;
            var nextIteration = new List<string>();

            while (!isStable)
            {
                isStable = true;
                nextIteration = new List<string>();

                for (var y = 0; y < heigth; y++)
                {
                    var newRow = "";

                    for (var x = 0; x < length; x++)
                    {
                        if (input[y][x] == '.')
                        {
                            newRow += '.';
                        }

                        if (input[y][x] == 'L' && HowManyNeighbours(input, x, y) == 0)
                        {
                            newRow += '#';
                            isStable = false;
                        }

                        if (input[y][x] == '#' && HowManyNeighbours(input, x, y) >= 4)
                        {
                            newRow += 'L';
                            isStable = false;
                        }

                        else
                        {
                            newRow += input[y][x];
                        }

                        nextIteration.Add(newRow);
                    }
                }
            }

            var seatsOccupied = nextIteration
                                            .Select(row => row.Count(seat => seat == '#'))
                                            .Sum();

            return seatsOccupied;
        }



        public static int HowManyNeighbours(List<string> input, int xCoordinate, int yCoordinate)
        {
            var ymax = input.Count()-1;
            var xmax = input[0].Length-1;

            var result = 0;

            //check East
            if (xCoordinate != xmax && input[yCoordinate][xCoordinate + 1] == '#') { result++; }
            if (xCoordinate != 0    && input[yCoordinate][xCoordinate - 1] == '#') { result++; }
            if (yCoordinate != ymax && input[yCoordinate+1][xCoordinate] == '#') { result++; }
            if (yCoordinate != 0    && input[yCoordinate-1][xCoordinate] == '#') { result++; }
            if (xCoordinate != xmax && yCoordinate !=ymax && input[yCoordinate+1][xCoordinate + 1] == '#') { result++; }
            if (xCoordinate != xmax && yCoordinate != 0 && input[yCoordinate-1][xCoordinate + 1] == '#') { result++; }
            if (xCoordinate != 0 && yCoordinate != ymax && input[yCoordinate+1][xCoordinate - 1] == '#') { result++; }
            if (xCoordinate != 0 && yCoordinate != 0 && input[yCoordinate-1][xCoordinate - 1] == '#') { result++; }

            return result;
        }
    }
}
