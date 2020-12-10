using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8
{
    public class ConsoleExecutor
    {
        private int _accumulator;
        private int _currentline;
        private List<int> _visitedLines;

        public int FindValueAccumulator(List<string[]> input)
        {
            _accumulator = 0;
            _currentline = 0;
            _visitedLines = new List<int>();
            var maxline = input.Count;

            while (!_visitedLines.Contains(_currentline))
            {
                if (_currentline==maxline)
                {
                    return _accumulator;
                }

                var command = input[_currentline];
                _visitedLines.Add(_currentline);
                ExecuteCommand(command);
            }

            return _accumulator;
        }

        public int RepairProgram(List<string[]> input)
        {
            var programLength = input.Count;

            for (var i = 0; i < programLength; i++)
            { 
                var data = System.IO.File
                    .ReadAllLines(@"C:\Users\Hcagny\source\repos\AdventOfCode2020\Day8\Data.txt")
                    .Select(s => s.Split(" "))
                    .ToList();

                var tweakedProgram = TweakProgramAtLine(data, i);

                if (!IsInfiniteLoop(tweakedProgram))
                {
                    return FindValueAccumulator(tweakedProgram);
                }
            }

            return -1000;
        }

        public List<string[]> TweakProgramAtLine(List<string[]> input, int line)
        {
            var answer = input;
            var command = answer[line][0];

            switch (command)
            {
                case "jmp":
                    answer[line][0] = "nop";
                    break;

                case "acc":
                    break;

                case "nop":
                    answer[line][0] = "jmp";
                    break;

                default:
                    throw new ArgumentException();
            }

            return answer;
        }

        public bool IsInfiniteLoop(List<string[]> input)
        {
            _currentline = 0;
            _accumulator = 0;
            _visitedLines = new List<int>();
            var max = input.Count;

            while (true)
            {
                if (_currentline == max-1)
                {
                    return false;
                }

                if (_visitedLines.Contains(_currentline))
                {
                    return true;
                }

                var command = input[_currentline];
                _visitedLines.Add(_currentline);
                ExecuteCommand(command);
            }
        }

        private void ExecuteCommand(IReadOnlyList<string> command)
        {
            switch (command[0])
            {
                case "jmp":
                    _currentline += int.Parse(command[1]);
                    break;

                case "acc":
                    _currentline++;
                    _accumulator += int.Parse(command[1]);
                    break;

                case "nop":
                    _currentline++;
                    break;

                default:
                    throw new ArgumentException();
            }
        }
    }
}