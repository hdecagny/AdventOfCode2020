using System;
using System.Linq;

namespace Day2
{
    public class PasswordVerificator
    {
        private readonly string _password;
        private readonly int _minimum;
        private readonly int _maximum;
        private readonly char _character;

        public PasswordVerificator(string input)
        {
            var splittedString = input.Split('-', ' ',':');
            _minimum = int.Parse(splittedString[0]);
            _maximum = int.Parse(splittedString[1]);
            _character = splittedString[2][0];
            _password = splittedString[4];
        }

        public bool IsValidPart1()
        {
            var occurence = _password.Count(c => c == _character);

            return (occurence <= _maximum && occurence >= _minimum);

        }

        public bool IsValidPart2()
        {
            var bool1 = _password[_minimum - 1] == _character;
            var bool2 = _password[_maximum - 1] == _character;

            return (bool1 ^ bool2);
        }

    }
}