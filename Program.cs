using System.Diagnostics;

namespace AlgoEfficiency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GenerateRandomArr(10000); // 10mila
            int[] array2 = GenerateRandomArr(100000); // 100mila
            int[] array3 = GenerateRandomArr(1000000); // 1M


            int[] bubbleArr = (int[])array.Clone();
            int[] bubbleArr2 = (int[])array2.Clone();

            int[] mergeArr = (int[])array.Clone();
            int[] mergeArr2 = (int[])array2.Clone();
            int[] mergeArr3 = (int[])array3.Clone();


            // MergeSort
            Console.WriteLine("\n\nMERGESORT ALGORITHM - Time Complexity O(n log(n))");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MergeSort(mergeArr, 0, mergeArr.Length - 1);
            sw.Stop();
            Console.WriteLine($"MergeSort 10k elements: {sw.ElapsedMilliseconds} ms");

            sw = new Stopwatch();
            sw.Start();
            MergeSort(mergeArr2, 0, mergeArr2.Length - 1);
            sw.Stop();
            Console.WriteLine($"MergeSort 100k elements: {sw.ElapsedMilliseconds} ms");

            sw = new Stopwatch();
            sw.Start();
            MergeSort(mergeArr3, 0, mergeArr3.Length - 1);
            sw.Stop();
            Console.WriteLine($"MergeSort 1M elements: {sw.ElapsedMilliseconds} ms");


            // BubbleSort 
            Console.WriteLine("\n\nBUBBLESORT ALGORITHM - Time Complexity O(n^2)");
            sw = new Stopwatch();
            sw.Start();
            BubbleSort(bubbleArr);
            sw.Stop();
            Console.WriteLine($"BubbleSort 10k elements: {sw.ElapsedMilliseconds} ms");

            sw = new Stopwatch();
            sw.Start();
            BubbleSort(bubbleArr2);
            sw.Stop();
            Console.WriteLine($"BubbleSort 100k elements: {sw.ElapsedMilliseconds} ms");

            Console.ReadLine();

        }



        private static void BubbleSort(int[] bubbleArr)
        {
            int n = bubbleArr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (bubbleArr[j] > bubbleArr[j + 1])
                        Swap(ref bubbleArr[j], ref bubbleArr[j + 1]);
        }



        static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        static void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];
            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, mid + 1, R, 0, n2);
            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    array[k++] = L[i++];
                }
                else
                {
                    array[k++] = R[j++];
                }
            }
            while (i < n1)
            {
                array[k++] = L[i++];
            }
            while (j < n2)
            {
                array[k++] = R[j++];
            }
        }


        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
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
