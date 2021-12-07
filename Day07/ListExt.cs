namespace Day07
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ListExt
    {
        public static int Median(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var data = source.OrderBy(n => n).ToArray();
            if (data.Length == 0)
                throw new InvalidOperationException();
            if (data.Length % 2 == 0)
                return (data[data.Length / 2 - 1] + data[data.Length / 2]) / 2;
            return data[data.Length / 2];
        }


      
    }
}
