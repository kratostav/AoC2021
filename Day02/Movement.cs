namespace Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Movement
    {
        Direction dir;
        int steps;

        public Movement(Direction dir, int steps)
        {
            this.dir = dir;
            this.steps = steps;
        }

        public Direction Dir { get => this.dir; set => this.dir = value; }
        public int Steps { get => this.steps; set => this.steps = value; }

        public Movement(string input)
        {
            var split = input.Split(' ');
            this.dir = (Direction)Enum.Parse(typeof(Direction), split[0], true);
            this.steps = int.Parse(split[1], System.Globalization.NumberStyles.Integer);
        }
    }
}
