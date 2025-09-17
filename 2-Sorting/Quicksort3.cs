using ALGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Sorting
{
    public static class Quicksort3
    {
        public static void quicksort3(ISortList list)
        {
            if (list == null || list.Count <= 1) return;
            quicksort3(list, 0, list.Count - 1);
        }

        private static void quicksort3(ISortList list, int left, int right)
        {
            if (left >= right) return;

            int pivotIndex = MedianOfThreeIndex(list, left, right);
            int newPivot = Quicksort.partition(list, pivotIndex, left, right);
            quicksort3(list, newPivot + 1, right);
        }

        private static int MedianOfThreeIndex(ISortList list, int left, int right)
        {
            int mid = left + (right - left) / 2;
            int a = left, b = mid, c = right;

            if (list.compare(a, b) < 0)
            {
                if (list.compare(b, c) < 0) return b;
                return (list.compare(a, c) < 0) ? c : a;
            }
            else
            {
                if (list.compare(a, c) < 0) return a;
                return (list.compare(b, c) < 0) ? c : b;
            }
        }
    }
}
