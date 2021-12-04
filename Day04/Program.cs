namespace Day04
{
    using CommonLib;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> drawings;
            List<BingoBoard> boards;
            var input = FileReading.GetInput("input.txt");
            boards = new List<BingoBoard>();
            var inputEnumerator = input.GetEnumerator();
            inputEnumerator.MoveNext();
            drawings = inputEnumerator.Current.Split(",").Select(x => x.Trim()).Select(int.Parse);
            inputEnumerator.MoveNext();
            while (inputEnumerator.MoveNext())
            {
                var boardLines = new List<string>();
                while (inputEnumerator.Current.Trim() != String.Empty)
                {                    
                    boardLines.Add(inputEnumerator.Current);
                    if(!inputEnumerator.MoveNext())
                    {
                        break;
                    }
                }
                boards.Add(new BingoBoard(boardLines));
            }
            Console.WriteLine("AoC - Day04");
            Console.WriteLine("Solution Part 1:");
            Console.WriteLine(Part1(drawings,boards));
            boards.ForEach(x => x.ResetBoard()); // Reset All boards
            Console.WriteLine("Solution Part 2:");
            Console.WriteLine(Part2(drawings, boards));
            Console.ReadLine();
        }

        static int Part1(IEnumerable<int> drawings,IEnumerable<BingoBoard> boards)
        {
            foreach (var draw in drawings)
            {
                boards.ToList().ForEach(x => x.MarkCell(draw));

                var winner = boards.FirstOrDefault(x => x.IsBingo());
                if(winner!=null)
                {
                    return winner.UnmarkedCells.Aggregate(0, (x, y) => x + y.Value) * draw;
                }
            }
            return -1;
        }

        static int Part2(IEnumerable<int> drawings, List<BingoBoard> boards)
        {
            foreach (var draw in drawings)
            {
                boards.ForEach(x => x.MarkCell(draw));
                if (boards.Count > 1)
                {
                    boards.RemoveAll(x => x.IsBingo());
                }
                else
                {
                    if ((bool)(boards.FirstOrDefault()?.IsBingo()))
                    {
                        return boards.FirstOrDefault().UnmarkedCells.Aggregate(0, (x, y) => x + y.Value) * draw;
                    }
                }                
            }
            return -1;
        }
    }
}
