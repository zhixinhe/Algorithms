// See https://aka.ms/new-console-template for more information
public class program
{
    public static int[] BubbleSort(int N, int[] arr)
    {
        int temp;
        int[] result = new int[N];
        for (int i=0; i<N; i++)
        {
            result[i] = arr[i];
        }
        for (int i=0; i<N; i++)
        {
            for (int j=0; j<N-i-1; j++)
            {
                if (result[j] > result[j+1])
                {
                    temp = result[j];
                    result[j] = result[j+1];
                    result[j+1] = temp;
                }
            }
        }
        return result;
    }
    public static int[] MergeSort(int N, int[] arr)
    {
        if (N == 1) return arr;

        // sort the first half of the array
        int n = N / 2;
        int[] left = new int[n];
        for (int i=0; i<N/2; i++)
        {
            left[i] = arr[i];
        }
        left = MergeSort(n, left);

        // sort the second half of the array
        int m = N - n;
        int[] right = new int[m];
        for (int i=0; i<m; i++)
        {
            right[i] = arr[i + n];
        }
        right = MergeSort(m, right);

        // merge the two sorted halves
        int il = 0;
        int ir = 0;
        int[] result = new int[N];
        for (int i=0; i<N; i++)
        {
            if (ir < m && il < n)
            {
                if (left[il] < right[ir])
                {
                    result[i] = left[il];
                    il++;
                } else {
                    result[i] = right[ir];
                    ir++;
                }
            } else if (ir == m) {
                result[i] = left[il];
                il++;
            } else {
                result[i] = right[ir];
                ir++;
            }
        }
        return result;
    }

    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        for (int i=0; i<N; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        int[] result = MergeSort(N, arr);
        Console.Write("after merge sort: ");
        for (int i=0; i<N; i++)
        {
            Console.Write($"{result[i]} ");
        }
        Console.WriteLine();

        result = BubbleSort(N, arr);
        Console.Write("after Bubble sort: ");
        for (int i=0; i<N; i++)
        {
            Console.Write($"{result[i]} ");
        }
        Console.WriteLine();
    }
}

