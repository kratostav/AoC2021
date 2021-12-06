namespace Day05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ventline
    {
        Point start;
        Point end;

        public Ventline(string input)
        {
            var split = input.Split("->");
            var s_start = split[0].Trim();
            var s_end = split[1].Trim();

            this.start = new Point(int.Parse(s_start.Split(',')[0].Trim()), int.Parse(s_start.Split(',')[1].Trim()));
            this.end = new Point(int.Parse(s_end.Split(',')[0].Trim()), int.Parse(s_end.Split(',')[1].Trim()));
        }

        public Point Start { get => this.start; }
        public Point End { get => this.end; }
    }
}
