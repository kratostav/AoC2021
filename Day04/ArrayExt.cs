namespace Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    public static class ArrayExt
    {
        public static T[] GetColumn<T>(this T[,] matrix, int columnNumber) => Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();

        public static T[] GetRow<T>(this T[,] matrix, int rowNumber) => Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();

        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((item, index) => (item, index));

        public static IEnumerable<T[]> Filter<T>(this T[,] source, Func<T[], bool> predicate)
        {
            for (var i = 0; i < source.GetLength(0); ++i)
            {
                var values = new T[source.GetLength(1)];
                for (var j = 0; j < values.Length; ++j)
                {
                    values[j] = source[i, j];
                }
                if (predicate(values))
                {
                    yield return values;
                }
            }
        }
        public static IEnumerable<T> Flatten<T>(this T[,] map)
        {
            for (var row = 0; row < map.GetLength(0); row++)
            {
                for (var col = 0; col < map.GetLength(1); col++)
                {
                    yield return map[row, col];
                }
            }
        }
    }
}
