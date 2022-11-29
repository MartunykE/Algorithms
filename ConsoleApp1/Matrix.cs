using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Matrix
    {
        public void Main()
        {

            // 1 2  2 0
            // 3 4  1 2
            var m1 = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            var m2 = new int[2, 2] { { 2, 0 }, { 1, 2 } };

            var result = new int[2, 2];

            for (int i = 0; i < m1.Length / 2 ; i++)
            {
                for (int j = 0; j < m1.Length / 2; j++)
                {
                    var res = 0;
                    for (int k = 0; k < m1.Length / 2; k++)
                    {
                        res += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = res;
                }
            }


            for (int i = 0; i < m1.Length / 2; i++)
            {
                for (int j = 0; j < m1.Length / 2; j++)
                {
                    Console.Write(result[i, j] + "  ");
                }
                Console.WriteLine();
            }



        }
    }
}
