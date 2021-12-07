namespace Day06
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
            long[] fish = new long[9];
            foreach (var item in input)
            {
                var inputs = item.Split(",").ToList().Select(long.Parse);

                foreach (var number in inputs)
                {
                    fish[number]++;
                }
            }
            Console.WriteLine("AoC - Day01");
            Console.WriteLine("Solution Part 1:");
            Console.WriteLine(Simulate(fish.ToArray(), 80));
            Console.WriteLine("Solution Part 2:");
            Console.WriteLine(Simulate(fish.ToArray(), 256));
            Console.ReadLine();
        }


        static long Simulate(long[] fish, int days)
        {
            for (var i = 0; i < days; i++)
            {
                var oldFishes = fish[0];
                for (var j = 1; j < fish.Length; j++)
                {
                    fish[j - 1] = fish[j];
                }
                fish[6] += oldFishes;
                fish[8] = oldFishes;
            }

            return fish.Aggregate((x, y) => x + y);
        }
    }
}
