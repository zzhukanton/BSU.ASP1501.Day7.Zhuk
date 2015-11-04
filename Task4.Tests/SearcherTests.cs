using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Task4.Tests
{
    [TestFixture]
    public class SearcherTests
    {
        [TestCase(new int[] { 1, 4, 6, 19, 20 }, 4, Result = 1)]
        [TestCase(new int[] { 1, 4, 6, 19, 20 }, 0, Result = -1)]
        [TestCase(null, 1, ExpectedException = typeof(ArgumentNullException))]
        public int BinarySeach_DefaultWithInts(int[] array, int element)
        {
            return array.BinarySearch<int>(element);
        }

        [TestCase(new int[] { 1, 4, 6, 19, 20 }, 4, null, ExpectedException = typeof(ArgumentNullException))]
        public int BinarySearch_WithComparerWithInts(int[] array, int element, Comparer<int> comparer)
        {
            return array.BinarySearch<int>(element, comparer);
        }

        [TestCase(new int[] { 1, 4, 6, 19, 20 }, 4, null, ExpectedException = typeof(ArgumentNullException))]
        public int BinarySearch_WithComparisionWithInts(int[] array, int element, Comparison<int> comparision)
        {
            return array.BinarySearch<int>(element, comparision);
        }

        [TestCase(new char[] { 'a', 'b', 'd', 'f', 'j' }, 'f', Result = 3)]
        [TestCase(new char[] { 'a', 'b', 'd', 'f', 'j' }, 'k', Result = -1)]
        [TestCase(null, 'f', ExpectedException = typeof(ArgumentNullException))]
        public int BinarySearch_WithCharsDefault(char[] array, char element)
        {
            return array.BinarySearch<char>(element);
        }
    }
}
