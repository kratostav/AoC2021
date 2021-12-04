namespace Day03
{
    using CommonLib;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static IEnumerable<int> integers;
        static int len = 0;
        static void Main(string[] args)
        {
            var input = FileReading.GetInput("input.txt");
            len = input.First().Length;
            integers = input.Select(x => Convert.ToInt32(x, 2));
            Console.WriteLine("AoC - Day03");
            Console.WriteLine("Solution Part 1:");
            Console.WriteLine(Part1(integers));
            Console.WriteLine("Solution Part 2:");
            Console.WriteLine(Part2(integers));
            Console.ReadLine();
        }


        static int countOnes(IEnumerable<int> input, int pos)
        {
            var ones = 0;
            foreach (int num in input)
            {
                if ((num & (1 << pos)) != 0)
                {
                    ones++;
                }
            }
            return ones;
        }


        static int GetmostCommonbit(IEnumerable<int> input, int pos)
        {
            var ones = countOnes(input, pos);
            return input.Count() - ones <= ones ? 1 : 0;
        }

        static int Part1(IEnumerable<int> input)
        {
            int gamma = 0;
            int epsilon = 0;

            for (int i=0;i<len;i++)
            {
                gamma |= GetmostCommonbit(input, i) << i;
            }
            epsilon = gamma ^ (1<<len)-1;
            return epsilon * gamma;
        }


        static int Part2(IEnumerable<int> input)
        {
            var oxygen = new List<int>(input);
            var co2 = new List<int>(input);

            for (int i = --len; i >= 0/*12*/; i--)
            {
                var mc = GetmostCommonbit(oxygen, i);

                if (oxygen.Count() > 1)
                    oxygen = oxygen.Where(x => ((x >> i) & 1) == mc).ToList();
               
                mc = GetmostCommonbit(co2, i);

                if (co2.Count() > 1)
                    co2 = co2.Where(x => ((x >> i) & 1) != mc).ToList();
               
                if (oxygen.Count() == 1 && co2.Count() == 1)
                    break;
            }
            
            return oxygen.First() * co2.First();
        }


    } 
}
