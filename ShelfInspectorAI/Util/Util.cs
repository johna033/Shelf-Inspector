using System;
using System.Collections.Generic;

namespace ShelfInspectorAI.Util
{
    public sealed class Util
    {
        //Fisher-Yates shuffle
        public static int[] ArrayShuffle(int[] array)
        {
            int length = array.Length;
            Random random = new Random();

            for (int i = 0; i < length - 2; i++)
            {
                int j = random.Next(i, length);
                int tmp = array[j];
                array[j] = array[i];
                array[i] = tmp;
            }

            return array;
        }

        public static List<T> AllocateList<T>(int capacity) where T: class
        {
            List<T> result = new List<T>();
            for (int i = 0; i < capacity; i++)
            {
                result.Add(null);
            }
            return result;
        }
    }
}
