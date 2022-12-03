using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class KnuthMorrisPrattSubstring
    {
        public void Main()
        {
            var text = "ABC ABCDAB ABCDABCDABDE ABCDABDABCDABD";
            var pattern = "ABCDABD";

            var table = CreateLPSTable(pattern);

            foreach (var item in table)
            {
                Console.Write(item + "  ");
            };

            int occurences = 0;
            var patternCursor = 0;
            int i = 0;
            while (i < text.Length)
            {
                if (text[i] == pattern[patternCursor])
                {
                    if (patternCursor == pattern.Length-1)
                    {
                        occurences++;
                        patternCursor = 0;
                    }
                    else
                    {
                        patternCursor++;
                        i++;
                        continue;
                    }
                }

                if (patternCursor != 0)
                {
                    var offset = table[patternCursor - 1];
                    patternCursor = offset;
                    continue;
                }

                i++;
            }

            Console.WriteLine($"Occurences : {occurences}");
        }


        public int[] CreateLPSTable(string pattern)
        {
            int[] lpsTable = new int[pattern.Length];
            lpsTable[0] = 0;
            var i = 0;
            var j = 1;

            while (j < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    lpsTable[j] = i + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (i == 0)
                    {
                        lpsTable[j] = 0;
                        j++;
                    }
                    else
                    {
                        i = lpsTable[i - 1];
                        continue;
                    }
                }
            }

            return lpsTable;
        }
    }
}
