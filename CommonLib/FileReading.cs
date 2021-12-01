namespace CommonLib
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class FileReading
    {
        public static IEnumerable<string> GetInput(string filename)
        {
            if (File.Exists(filename))
            {
                return File.ReadAllLines(filename).ToList();
            }
            throw new Exception($"Couldn't locate input file {filename}");
        }

        public static IEnumerable<int> AllNumbers(IEnumerable<string> input)
        {
            var integers = input.Select(int.Parse);

            return integers;
        }

        public static IEnumerable<int> AllNumbers(string filename)
        {
            var integers = AllNumbers(GetInput(filename));

            return integers;
        }

    }
}
