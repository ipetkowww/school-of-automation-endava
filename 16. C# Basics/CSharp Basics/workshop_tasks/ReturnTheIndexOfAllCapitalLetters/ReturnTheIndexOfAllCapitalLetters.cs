using System;
using System.Collections.Generic;

namespace ReturnTheIndexOfAllCapitalLetters
{
    internal class ReturnTheIndexOfAllCapitalLetters
    {
        static void Main()
        {
            int[] vs = GetIndexOfAllCapitalLetters("eDaBiT");
            int[] vs1 = GetIndexOfAllCapitalLetters("eQuINoX");
            Console.WriteLine("[{0}]", string.Join(", ", vs));
            Console.WriteLine("[{0}]", string.Join(", ", vs1));
        }

        static int[] GetIndexOfAllCapitalLetters(string text)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (Char.IsUpper(currentChar))
                {
                    result.Add(i);
                }
            }
            return SortArrayAscending(result.ToArray());
        }

        static int[] SortArrayAscending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
    }
}
