using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BoyerMooreSubstring
    {
        public void Main()
        {
            var text = "BoyerMooreSubsetringBoyerMooreMooreSubstring";

            var searchedSubscting = "Moore";

            var step = searchedSubscting.Length - 1;

            int occurrence = 0;

            for (int textCursor = step; textCursor < text.Length; textCursor++)
            {
                if (text[textCursor] == searchedSubscting[step])
                {
                    bool matched = true;
                    for (int i = 0; i < step; i++)
                    {
                        if (text[textCursor - step + i] != searchedSubscting[i])
                        {
                            matched = false;
                            break;
                        }
                    }

                    if (matched)
                    {
                        occurrence++;
                    }
                }
            }


            Console.WriteLine("text " + text);
            Console.WriteLine("searched subscting: " + searchedSubscting);
            Console.WriteLine($"Occurence: {occurrence}");
        }
    }
}
