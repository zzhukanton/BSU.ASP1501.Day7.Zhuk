using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class Searcher
    {
        public static int BinarySearch<T>(this T[] array, T element, IComparer<T> comparer)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null");
            if (comparer == null)
                throw new ArgumentNullException("Comparer is null");

            int middle, left = 0, right = array.Length - 1;

            while (left <= right)
            {
                middle = left + (right - left) / 2;

                int order = comparer.Compare(array[middle], element);
                if (order == 0)
                    return middle;
                if (order > 0)
                    right = middle - 1;
                else
                    left = middle + 1;
            }
            return -1;
        }

        public static int BinarySearch<T>(this T[] array, T element)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null");

            return array.BinarySearch<T>(element, Comparer<T>.Default);
        }

        public static int BinarySearch<T>(this T[] array, T element, Comparison<T> comparision)
        {
            if (comparision == null)
                throw new ArgumentNullException("Comparision is null");

            return array.BinarySearch<T>(element, Comparer<T>.Create(comparision));
        }
    }
}
