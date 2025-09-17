using ALGA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Sorting
{
    public static class SortBench
    {
        public static (double seconds, long comps, long swaps, long gets, long sets)
           Measure(Action<ISortList> sort, Func<SortList> makeInput, int repeats = 10)
        {
            var sw = new Stopwatch();
            long comps = 0, swaps = 0, gets = 0, sets = 0;

            sw.Start();
            for (int r = 0; r < repeats; r++)
            {
                var list = makeInput();  // fresh list every run
                sort(list);
                comps += list.Comparisons;
                swaps += list.Swaps;
                gets += list.Gets;
                sets += list.Sets;
            }
            sw.Stop();

            double secPerRun = sw.Elapsed.TotalSeconds / repeats;
            return (secPerRun, comps / repeats, swaps / repeats, gets / repeats, sets / repeats);
        }

        public static void RunAll()
        {
            const int N = 1000;

            Func<SortList> Sorted = () => new SortList(N, sorted: true); // "gesorteerd" (desc by default)
            Func<SortList> Random = () => new SortList(N);               // shuffled

            Print("Quicksort (leftmost) – sorted   ", Measure(Quicksort.quicksort, Sorted));
            Print("Quicksort (leftmost) – random   ", Measure(Quicksort.quicksort, Random));
            Print("Quicksort3 (median) – sorted    ", Measure(Quicksort3.quicksort3, Sorted));
            Print("Quicksort3 (median) – random    ", Measure(Quicksort3.quicksort3, Random));
            Print("Mergesort – sorted              ", Measure(Mergesort.mergesort, Sorted));
            Print("Mergesort – random              ", Measure(Mergesort.mergesort, Random));
            Print("Bubblesort – sorted             ", Measure(Bubblesort.bubblesort, Sorted));
            Print("Bubblesort – random             ", Measure(Bubblesort.bubblesort, Random));
        }

        private static void Print(string name, (double s, long c, long sw, long g, long set) r)
        {
            Console.WriteLine($"{name} | time/run = {r.s:0.000000}s | comps = {r.c} | swaps = {r.sw} | gets = {r.g} | sets = {r.set}");
        }
    }
}
