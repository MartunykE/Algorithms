using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            //var m = new Matrix();
            //m.Main();

            //var c = new ClosestPair();
            //c.Main();

            //var bm = new BoyerMooreSubstring();
            //bm.Main();

            var kmp = new KnuthMorrisPrattSubstring();
            kmp.Main();

            //MergeSort sort = new MergeSort();
            //sort.Main();
        }

        private void PrintDiamond()
        {
            var size = 9;
            var middle = size / 2;

            var step = 2;


            var starStartpoint = middle;
            var starEndpoint = middle;

            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (k < starStartpoint || k > starEndpoint)
                    {
                        Console.Write("!");
                    }
                    else
                    {
                        Console.Write("*");

                    }
                }

                if (i < middle)
                {
                    starStartpoint -= step / 2;
                    starEndpoint += step / 2;
                }
                else
                {
                    starStartpoint += step / 2;
                    starEndpoint -= step / 2;
                }

                Console.WriteLine();
            }
        }

    }


}
