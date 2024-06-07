using System.Diagnostics;

namespace AlgoEfficiency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GenerateRandomArr(10000); // 10mila
            int[] array2 = GenerateRandomArr(100000); // 100mila
            int[] array3 = GenerateRandomArr(1000000); // 1milione
            int[] array4 = GenerateRandomArr(10000000); // 10milioni

            int[] bubbleArr = (int[])array.Clone();
            int[] bubbleArr2 = (int[])array2.Clone();
            int[] bubbleArr3 = (int[])array3.Clone();
            int[] bubbleArr4 = (int[])array4.Clone();

            int[] quickArr = (int[])array.Clone();
            int[] quickArr2 = (int[])array2.Clone();
            int[] quickArr3 = (int[])array3.Clone();
            int[] quickArr4 = (int[])array4.Clone();

            // BubbleSort 
            Console.WriteLine("BUBBLE SORT ALGORITHM - Time Complexity O(n^2)");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BubbleSort(bubbleArr);
            sw.Stop();
            Console.WriteLine($"BubbleSort 10k elements: {sw.ElapsedMilliseconds} ms");

            sw = new Stopwatch();
            sw.Start();
            BubbleSort(bubbleArr2);
            sw.Stop();
            Console.WriteLine($"BubbleSort 100k elements: {sw.ElapsedMilliseconds} ms");

            //sw = new Stopwatch();
            //sw.Start();
            //BubbleSort(bubbleArr3);
            //sw.Stop();
            //Console.WriteLine($"BubbleSort 1 million elements: {sw.ElapsedMilliseconds} ms");

            //sw = new Stopwatch();
            //sw.Start();
            //BubbleSort(bubbleArr4);
            //sw.Stop();
            //Console.WriteLine($"BubbleSort 10 million elements: {sw.ElapsedMilliseconds} ms");

            // QuickSort
            Console.WriteLine("\n\nQUICKSORT ALGORITHM - Time Complexity O(n log(n))");
            sw = new Stopwatch();
            sw.Start();
            QuickSort(quickArr, 0, quickArr.Length - 1);
            sw.Stop();
            Console.WriteLine($"QuickSort 10k elements: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();

            sw = new Stopwatch();
            sw.Start();
            QuickSort(quickArr2, 0, quickArr2.Length - 1);
            sw.Stop();
            Console.WriteLine($"QuickSort 100k elements: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();

            //sw = new Stopwatch();
            //sw.Start();
            //QuickSort(quickArr3, 0, quickArr3.Length - 1);
            //sw.Stop();
            //Console.WriteLine($"QuickSort 1 million elements: {sw.ElapsedMilliseconds} ms");
            //Console.ReadLine();

            //sw = new Stopwatch();
            //sw.Start();
            //QuickSort(quickArr4, 0, quickArr4.Length - 1);
            //sw.Stop();
            //Console.WriteLine($"QuickSort 10 million elements: {sw.ElapsedMilliseconds} ms");
            //Console.ReadLine();
        }



        private static void BubbleSort(int[] bubbleArr)
        {
            int n = bubbleArr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (bubbleArr[j] > bubbleArr[j + 1])
                        Swap(ref bubbleArr[j], ref bubbleArr[j + 1]);
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void QuickSort(int[] quickArr, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(quickArr, low, high);
                QuickSort(quickArr, low, pivot - 1);
                QuickSort(quickArr, pivot + 1, high);
            }
        }

        private static int Partition(int[] quickArr, int low, int high)
        {
            int pivot = quickArr[high];
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (quickArr[j] < pivot)
                {
                    i++;
                    Swap(ref quickArr[i], ref quickArr[j]);
                }
            }
            Swap(ref quickArr[i + 1], ref quickArr[high]);
            return i + 1;
        }

        private static int[] GenerateRandomArr(int length)
        {
            Random random = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, length);
            }
            return array;
        }
    }

}
