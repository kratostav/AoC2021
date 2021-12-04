namespace Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class BingoBoard
    {
        BingoCell[,] cells;

        public bool IsBingo()
        {
            for (var i = 0; i < this.cells.GetLength(0); i++) //5x5 grid so we need only one Loop
            {
                if (this.cells.GetRow(i).Where(x => x.Marked).Count() == 5 || this.cells.GetColumn(i).Where(x => x.Marked).Count() == 5)
                {
                    return true;
                }
            }
            return false;
        }


        public BingoBoard(IEnumerable<string> lines)
        {
            this.cells = new BingoCell[5, 5];
            foreach (var (line, r) in lines.WithIndex())
            {
                var cols = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var (col, c) in cols.WithIndex())
                {
                    this.cells[r, c] = new BingoCell(int.Parse(col));
                }
            }
        }

        public void MarkCell(int val) => this.cells.Flatten().Where(x => x.Value == val).ToList().ForEach(x => x.Mark());

        public List<BingoCell> UnmarkedCells => this.cells.Flatten().Where(x => !x.Marked).ToList();

        public void ResetBoard() => this.cells.Flatten().ToList().ForEach(x => x.UnMark());
    }
}
