using System.Diagnostics;

namespace SeriesC.EAsynchronus;

public class Multithread
{
    /*
     * Thread, jalur eksekusi kode di dalam program
     * Program itu selalu punya satu thread utama (Main thread) yang menjalan Main() Method
     * 
     * Multithread, memakai lebih dari satu thread
     * sehingga beberapa task bisa berjalan dalam waktu yang bersamaan
     * 
     */

    public static void ThreadExample()
    {
        Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"Total threads: {Process.GetCurrentProcess().Threads.Count}");

        Stopwatch stopwatch = Stopwatch.StartNew();

        GenerateReport("Laporan absensi");
        GenerateReport("Laporan Payroll");

        stopwatch.Stop();
        Console.WriteLine($"Without Threads: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine();

        // Dengan Thread
        stopwatch.Restart();

        Thread thread1 = new Thread(() => GenerateReport("Laporan absensi"));
        Thread thread2 = new Thread(() => GenerateReport("Laporan Payroll"));

        thread1.Start();
        thread2.Start();

        thread2.Join();
        thread2.Join();

        stopwatch.Stop();
        Console.WriteLine($"Without Threads: {stopwatch.ElapsedMilliseconds}ms");

    }

    public static void GenerateReport(string name)
    {
        Console.WriteLine($"Generating Report : {name} di thread {Thread.CurrentThread.ManagedThreadId}");

        Thread.Sleep(1000);
        Console.WriteLine($"Finished generating report: {name}");
    }

    public static void ConcurrencyAndParallelism()
    {
        Console.WriteLine($"Total Cores: {Environment.ProcessorCount}");

        // Task yang menunggu
        Stopwatch stopwatch = Stopwatch.StartNew();

        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() => Thread.Sleep(500));
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();
        Console.WriteLine($"Tasks waiting 500ms: {stopwatch.ElapsedMilliseconds}ms");


        //Task Concurrent
        int[] results = new int[5];
        stopwatch.Restart();
        for (int i = 0; i < 5; i++)
        {
            results[i] = CountPrimes(i * 500000, (i + 1) * 500000);
        }
        stopwatch.Stop();
        Console.WriteLine($"Concurrent: {stopwatch.ElapsedMilliseconds} ms, Result: {results.Sum()}");


        // Parallel, akan membagi ke beberapa core
        stopwatch.Restart();
        Parallel.For(0, 4, i =>
            {
                results[i] = CountPrimes(i * 500000, (i + 1) * 500000);
            });
        stopwatch.Stop();
        Console.WriteLine($"Parallel: {stopwatch.ElapsedMilliseconds} ms, Result: {results.Sum()}");
    }

    public static int CountPrimes(int from, int to)
    {
        int count = 0;

        for (int number = from; number < to; number++)
        {
            if (number < 2)
            {
                continue;
            }

            bool isPrime = true;
            for (int divisor = 2; divisor * divisor < number; divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) count++;
        }

        return count;
    }
}
