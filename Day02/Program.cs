namespace Day02
{
    using CommonLib;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = FileReading.GetInput("input.txt");
            var movements = input.Select(x => new Movement(x));
            Console.WriteLine("AoC - Day02");
            Console.WriteLine("Solution Part 1:");
            Console.WriteLine(Part1(movements));
            Console.WriteLine("Solution Part 2:");
            Console.WriteLine(Part2(movements));
            Console.ReadLine();
        }

        static int Part1(IEnumerable<Movement> movements)
        {
            int horizontal = 0;
            int depth = 0;

            foreach( var movement in movements)
            {
                switch(movement.Dir)
                {
                    case Direction.Down:
                        depth += movement.Steps;
                        break;
                    case Direction.Up:
                        depth -= movement.Steps;
                        break;
                    case Direction.Forward:
                        horizontal += movement.Steps;
                        break;
                }
            }

            return horizontal * depth;


        }


        static int Part2(IEnumerable<Movement> movements)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var movement in movements)
            {
                switch (movement.Dir)
                {
                    case Direction.Down:                        
                        aim += movement.Steps;
                        break;
                    case Direction.Up:                        
                        aim -= movement.Steps;
                        break;
                    case Direction.Forward:
                        horizontal += movement.Steps;
                        depth += aim * movement.Steps;
                        break;
                }
            }

            return horizontal * depth;


        }
    }

    

}
