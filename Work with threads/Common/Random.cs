using System;
using System.Collections.Generic;

namespace Work_with_threads.Common
{
    public static class Random
    {
        private static readonly System.Random _random;

        static Stack<string> numbers = new Stack<string>();
        private static List<string> formats = new List<string>() { "099", "077", "055" };

        static Random() => _random = new System.Random(DateTime.Now.Millisecond);


        private static string[] _names = new string[]
        {
            "Adam", "Alex", "Aaron", "Ben", "Carl", "Dan", "David", "Edward", "Fred", "Frank", "George", "Hal",
            "Hank", "Ike", "John", "Jack", "Joe", "Larry", "Monte", "Matthew", "Mark", "Nathan", "Otto", "Paul",
            "Peter", "Roger", "Roger", "Steve", "Thomas", "Tim", "Ty", "Victor", "Walter",
        };

        public static string GetRandomName() => _names[_random.Next(0, _names.Length)];

        public static string GetRandomNumber()
        {
            string number = "";
            string format = formats[_random.Next(0, formats.Count)];
            number += format;

            for (int i = 0; i < 3; i++)
            {
                number += $"-{_random.Next(0, 10)}{_random.Next(0, 10)}";
            }

            numbers.Push(number);
            if (numbers.Contains(number)) 
                return GetRandomNumber();

            return number;
        }
    }
}