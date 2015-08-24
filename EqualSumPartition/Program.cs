using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumPartition
{
    class Program
    {
        static int p = 8;
        static int[] data = new int[50];


        static void Main(string[] args)
        {
            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                data[i] = rnd.Next(1, 498);
            }

            EqualSumPartition eq = new EqualSumPartition();

            var t = eq.Calculate(data, p);

            for (int i = 0; i < t.Count; i++)
            {
                var a = t[i];
                Console.WriteLine(String.Join(",", a));
            }
        }
    }
}
