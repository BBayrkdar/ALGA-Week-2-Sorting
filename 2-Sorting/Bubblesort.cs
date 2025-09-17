using ALGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Sorting
{
    public static class Bubblesort
    {
        public static void bubblesort(ISortList list)
        {
            if (list == null || list.Count <= 1) return;

            int n = list.Count;
            bool swapped;
            do
            {
                swapped = false;
                int lastSwapAt = 0;

                for (int i = 1; i < n; i++)
                {
                    if (list.compare(i - 1, i) > 0)
                    {
                        list.swap(i - 1, i);
                        swapped = true;
                        lastSwapAt = i;
                    }
                }
                n = Math.Max(1, lastSwapAt);
            }
            while (swapped);
        }
    }
}
