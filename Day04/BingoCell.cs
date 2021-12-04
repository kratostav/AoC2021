namespace Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BingoCell
    {
        public int Value { get; }
        public bool Marked { get; private set; }

        public BingoCell(int value)
        {
            this.Value = value;
            this.Marked = false;
        }

        public void Mark() => this.Marked = true;
        public void UnMark() => this.Marked = false;


    }
}
