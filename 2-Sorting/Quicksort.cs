using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGA
{
    public class Quicksort
    {
        public static void quicksort(ISortList list)
        {
            if (list == null || list.Count <= 1) return;
            quicksort(list, 0, list.Count - 1);
        }

        private static void quicksort(ISortList list, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex) return;

            int pivotIndex = leftIndex;

            int newPivotIndex = partition(list, pivotIndex, leftIndex, rightIndex);

            quicksort(list, leftIndex, newPivotIndex - 1);
            quicksort(list, newPivotIndex + 1, rightIndex);
        }

        /**
         * Partition the list according to the value at the pivot index
         * This method should only partition the part of the array that is between startIndex and endIndex
         * All values lower than the pivot value should be to the left of the pivot value
         * and all values higher than the pivot value should be to the right of the pivot value
         * 
         * This method should return the position of the pivot value after partitioning is complete
         * 
         * For example: partition([4, 9, 5, 0, 2], 2, 0, 4)
         * should partition the values between indices 0...4 (inclusive) using the value 5 as the pivot
         * A possible partitioning would be: [2, 0, 4, 5, 9], this method should return 3 as that is where
         * the pivot value 5 has ended up.
         * This method may assume there are no equal values
         */
        public static int partition(ISortList list, int pivotIndex, int leftIndex, int rightIndex)
        {
            if (pivotIndex != rightIndex)
                list.swap(pivotIndex, rightIndex);

            int store = leftIndex;

            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (list.compare(i, rightIndex) < 0)
                {
                    if (i != store) list.swap(i, store);
                    store++;
                }
            }

            if (store != rightIndex) list.swap(store, rightIndex);

            return store;
        }
    }
}
