namespace Day05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Point
    {
        int x;
        int y;

        public int X { get => this.x; }
        public int Y { get => this.y; }

        public Point(int y, int x)
        {
            this.x = x;
            this.y = y;           
        }
    }
}
