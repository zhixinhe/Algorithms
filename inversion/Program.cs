public class Program
{
    public static int InversionBruteForce(int n, int[] arr)
    {
        int result = 0;
        for (int i=0; i<n; i++)
        {
            for (int j=i+1; j<n; j++)
            {
                if (arr[i] > arr[j]) result++;
            }
        }
        return result;
    }
    // a divide and conquer algorithm
    public static int Inversion(int n, int[] arr, int start, int end)
    {
        if (end - start == 1) return 0;
        int dp = (start + end) / 2;
        
        int result = Inversion(n, arr, start, dp) + Inversion(n, arr, dp, end);
        for (int i=dp; i<end; i++)
        {
            for (int j=start; j<dp; j++)
            {
                if (arr[i] < arr[j]) result++;
            }
        }
        return result;
    }
    public static void Main(string[] args)
    {
        Console.Write("Please input an integer:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Please input {n} integers, one per line:");
        int[] arr = new int[n];
        for (int i=0; i<n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine($"The number of inversions by divide and conquer is {Inversion(n, arr, 0, n)}.");
        Console.WriteLine($"The number of inversions by brute force is {InversionBruteForce(n, arr)}.");
    }
}
