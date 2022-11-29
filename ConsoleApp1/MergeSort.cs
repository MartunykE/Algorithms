using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MergeSort
    {
        public void Main()
        {
            Console.WriteLine("Start");
            //1  2  3  4  5  6  7  12  14
            var array = new int[] { 6, 1, 14, 3, 7, 2, 12, 5, 4 };
            //var array = new int[] { 2, 5, 7, 1, 6, 8, 10 };
            //var array = new int[] { 1, 3, 5, 2, 4, 6, 7 };

            var (sort, inversions) = SortArray(array);

            foreach (var item in sort)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("Inversions : " + inversions);

        }

        private (int[], int) SortArray(int[] array)
        {
            var leftLength = array.Length / 2;
            var left = new int[leftLength];
            var right = new int[array.Length - leftLength];

            var leftInversions = 0;
            var rightInversions = 0;

            Array.Copy(array, 0, left, 0, left.Length);
            Array.Copy(array, left.Length, right, 0, right.Length);

            if (leftLength > 1)
            {
                var (leftArr, leftInv) = SortArray(left);


                left = leftArr;
                leftInversions = leftInv;

                Console.WriteLine("L Invertions " + leftInversions);

                //(left, leftInversions) = SortArray(left);
            }

            if (right.Length > 1)
            {
                var (arr, inv) = SortArray(right);

                right = arr;
                rightInversions = inv;
                Console.WriteLine("R Invertions " + rightInversions);
                //(right, rightInversions) = SortArray(right);
            }

            var (res, splitInversions) = MergeArraysAndCountInversions(left, right);

            if (splitInversions > 0)
            {
                Console.WriteLine();
            }

            return (res, leftInversions + rightInversions + splitInversions);
        }

        public (int[], int) MergeArraysAndCountInversions(int[] array1, int[] array2)
        {
            var length = array1.Length + array2.Length;


            var result = new int[length];

            var inversions = 0;



            var i = 0;
            var j = 0;

            for (int k = 0; k < length; k++)
            {
                // add invertions here
                if (i >= array1.Length)
                {
                    Array.Copy(array2, j, result, k, length - k);

                    return (result, inversions);
                }

                if (j >= array2.Length)
                {
                    Array.Copy(array1, i, result, k, length - k);
                    //inversions += array1.Length - i + 1;


                    return (result, inversions);
                }

                //var array = new int[] { 1, 3, 5, 2, 4, 6 };

                if (array1[i] < array2[j])
                {
                    result[k] = array1[i];
                    i++;

                }
                else
                {
                    result[k] = array2[j];
                    inversions += array1.Length - i;
                    //inversions += length/ 2 - i + 1;
                    j++;
                }

            }


            return (result, inversions);
        }




    }
}
