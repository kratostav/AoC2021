namespace Day05
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
            var field = input.Select(x => new Ventline(x));
            Console.WriteLine("AoC - Day05");
            Console.WriteLine("Solution Part 1:");
            Console.WriteLine(Part1(field));           
            Console.WriteLine("Solution Part 2:");
            Console.WriteLine(Part2(field));
            Console.ReadLine();
        }

        static int Part1(IEnumerable<Ventline> field)
        {
            var points = new int[field.Max(x => Math.Max(x.Start.X, x.End.X))+1,field.Max(x => Math.Max(x.Start.Y, x.End.Y))+1];          
            foreach (var line in field)
            {
                if (line.Start.X == line.End.X)
                {
                    for (var i = Math.Min(line.Start.Y, line.End.Y); i <= Math.Max(line.Start.Y, line.End.Y); i++)
                    {
                        points[line.Start.X,i]++;
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    for (var i = Math.Min(line.Start.X, line.End.X); i <= Math.Max(line.Start.X, line.End.X); i++)
                    {
                        points[i,line.Start.Y]++;
                    }
                }
            }
            return points.Flatten().Where(x => x > 1).Count();
        }

        static int Part2(IEnumerable<Ventline> field)
        {
            var points = new int[field.Max(x => Math.Max(x.Start.X, x.End.X)) + 1, field.Max(x => Math.Max(x.Start.Y, x.End.Y)) + 1];
            foreach (var line in field)
            {
                if (line.Start.X == line.End.X)
                {
                    for (var i = Math.Min(line.Start.Y, line.End.Y); i <= Math.Max(line.Start.Y, line.End.Y); i++)
                    {
                        points[line.Start.X, i]++;
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    for (var i = Math.Min(line.Start.X, line.End.X); i <= Math.Max(line.Start.X, line.End.X); i++)
                    {
                        points[i, line.Start.Y]++;
                    }
                }
                else
                {
                    float xDiff = Math.Max(line.Start.X, line.End.X) - Math.Min(line.Start.X, line.End.X);
                    float yDiff = Math.Max(line.Start.Y, line.End.Y) - Math.Min(line.Start.Y, line.End.Y);
                    var angle = (int)Math.Abs((float)Math.Atan2(yDiff, xDiff) * (float)(180 / Math.PI));                   
                    if (angle == 45 || angle == (180 - 45)) //diagonal
                    {
                        var xStart = line.Start.X;
                        var yStart = line.Start.Y;

                        var xEnd = line.End.X;
                        var yEnd = line.End.Y;
                        points[xStart, yStart]++;
                        do
                        {                            
                            if (line.Start.X < line.End.X)
                            {
                                xStart++;
                            }
                            else if (line.Start.X > line.End.X)
                            {
                                xStart--;
                            }

                            if (line.Start.Y < line.End.Y)
                            {
                                yStart++;
                            }
                            else if (line.Start.Y > line.End.Y)
                            {
                                yStart--;
                            }
                            points[xStart, yStart]++;
                        } while (yStart != yEnd || xStart != xEnd);

                    }
                }
            }
            return points.Flatten().Where(x => x > 1).Count();
        }
       
    }


}
