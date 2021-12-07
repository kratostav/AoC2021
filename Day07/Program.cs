namespace Day07
{
    using CommonLib;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = FileReading.GetInput("input.txt"); // Read the Input file
            IEnumerable<int> crabs = null;
            foreach (var item in input)
            {
                crabs = item.Split(",").ToList().Select(int.Parse);
                
            }
            Console.WriteLine("AoC - Day01");
            Console.WriteLine("Solution Part 1:");
            Console.WriteLine(Part1(crabs));
            Console.WriteLine("Solution Part 2:");
            Console.WriteLine(Part2(crabs));
            Console.ReadLine();
        }


        static int Part1(IEnumerable<int> crabs)
        {
            var median = crabs.Median();

            return crabs.Aggregate(0,(x, y) => x + Math.Abs(y - median));
        }

        static int Part2(IEnumerable<int> crabs)
        {
            var average = (int)crabs.Average();

            return crabs.Aggregate(0, (x, y) => x + Math.Abs(y - average)*(Math.Abs(y - average)+1)/2);
        }
    }
}
