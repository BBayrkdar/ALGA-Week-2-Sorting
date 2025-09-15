using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGA
{
    public class Mergesort
    {
        public static void mergesort(ISortList list)
        {
            if (list == null || list.Count <= 1) return;
            mergesort(list, 0, list.Count - 1);
        }

        public static void mergesort(ISortList list, int leftIndex, int rightIndex)
        {
            if (list == null) return;
            if (leftIndex < 0 || rightIndex >= list.Count || leftIndex >= rightIndex) return;

            int mid = leftIndex + (rightIndex - leftIndex) / 2;

            mergesort(list, leftIndex, mid);
            mergesort(list, mid + 1, rightIndex);

            Merge(list, leftIndex, mid, rightIndex);
        }

        private static void Merge(ISortList list, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];
            for (int i = 0; i < n1; i++) L[i] = list[left + i];
            for (int j = 0; j < n2; j++) R[j] = list[mid + 1 + j];

            int a = 0, b = 0, k = left;
            while (a < n1 && b < n2)
            {
                if (L[a] <= R[b]) list[k++] = L[a++];
                else list[k++] = R[b++];
            }
            while (a < n1) list[k++] = L[a++];
            while (b < n2) list[k++] = R[b++];
        }
    }
}
