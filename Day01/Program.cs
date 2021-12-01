namespace Day01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommonLib;

    class Program
    {
        static void Main(string[] args)
        {

            var input = FileReading.AllNumbers("input.txt"); // Read the Input file
            Console.WriteLine("AoC - Day01");
            Console.WriteLine("Solution Part 1:");
            Console.WriteLine(CountIncreasingSums(input, 1));
            Console.WriteLine("Solution Part 2:");
            Console.WriteLine(CountIncreasingSums(input, 3));
            Console.ReadLine();
        }

        static int CountIncreasingSums(IEnumerable<int> numbers, int windowSize)
        {
            var copy = numbers;

            var rounds = numbers.Count() - windowSize; //calculate the Rounds via the Window size (needed for the Loop)
            var count = 0;

            for (var i = 0; i < rounds; i++)
            {
                // Split the List (left and right will be compared against)
                var left = copy;
                var right = copy.Skip(1);
                // sum up by the windows size
                var leftSum = left.Take(windowSize).Sum();
                var rightSum = right.Take(windowSize).Sum();
                // increase the count when the right side is bigger
                if (leftSum < rightSum)
                {
                    ++count;
                }
                // advance the List
                copy = copy.Skip(1);
            }

            return count;
        }
    }
}
