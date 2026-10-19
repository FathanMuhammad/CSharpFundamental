using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;

namespace SeriesC.EAsynchronus;

public class Asynchronus
{
/*
 * Asynchronus, memulai Task Tanpa membuat thread diam menunggu sampai task-nya selesai
 * Dipakai untuk task yang banyak menunggu: baca file, query database, API call
 * 
 * Thread   > membuat dan mengatur Thread sendiri (Start, Join)
 * Task     > mewakili pekerjaan yang hasilnya bisa disediakan nanti
 *            Thread diambil dari thread Pool, bisa return nnilai dan membawa exception
 *            
 * Async/await > cara menulis kode asynchronus agar terbaca seperti kode biasa
 */

    public static void TaskClass()
    {
        Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");

        // #1 Task.Run, menjalankan pekerjaan di thread lain dari thread pool
        Task task = Task.Run(() =>
        {
            Console.WriteLine($"Task Berjalan di Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
        });

        // Task void/wait tidak menunggu task selesai
        task.Wait();
        Console.WriteLine($"Status: {task.Status}");

        // #2 Task<T> task yang mengembalikan nilai
        Task<int> salaryTask = Task.Run(() => CalculateSalary(8000000, 15000000));

        // Result, menugngu task seelesai lalu mengambil hasilnya
        int salary = salaryTask.Result;
        Console.WriteLine($"Salary: {salary:N0}");

        // #3 menjalankan beberapa task sekaligus
        var stopwatch = Stopwatch.StartNew();

        Task<int> Task1 = Task.Run(() => CalculateSalary(8000000, 15000000));
        Task<int> Task2 = Task.Run(() => CalculateSalary(6500000, 5000000));
        Task<int> Task3 = Task.Run(() => CalculateSalary(12000000, 20000000));

        // Waitall, menunggu semua task selesai
        Task.WaitAll(Task1, Task2, Task3);

        // Apa Bedanya whenAll, WhenAny, Wheneach
        // wait > sync, blocking thread(menunggu task hingga benar-benar selesai) -> kalo di db, akan terjadi deadlock
        // when > async, non-block thread(Bisa mengerjakan task lain ketika task sedang berlangsung) 
        // --- ALL, menunggu semua task dan dijalankan secara bersamaan
        // --- ANY, Salah satu dari task yang selesai
        // --- EACH, Menjalankan Task secara berurutan hingga selesai satu / satu

        stopwatch.Stop();
        Console.WriteLine($"Total Payroll: {Task1.Result + Task2.Result + Task3.Result}");
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds}ms");


        // #4 Exception dalam task
        Task<int> failedtask = Task.Run(() => CalculateSalary(-1, 0));

        try
        {
            failedtask.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"Status: {failedtask.Status}");        
            Console.WriteLine($"Error {ex.InnerException?.Message}");        
        }

        // Wait dan result membuat thread call diam menunggu (Blocking)
        // cara menunggu tanpa blocking adalah await

    }

    public static int CalculateSalary(int baseSalary, int allowance)
    {
        if (baseSalary < 0) throw new ArgumentException("Gaji pokok gaboleh negatif");

        Thread.Sleep(500);
        return baseSalary + allowance;
    }

    public static async Task AsyncAwait()
    {
        /*
         * async    > menandai method sebagai asynchronus sehingga boleh memakai awati
         * awati    > menunggu task selesai tanpa membuat thread diam (non-blocking)
         * 
         * Selama menunggu, thread itu bakal dilepas release dan bisa mengerjakan hal lain
         * 
         * Return Tyoe Method async
         * Task     > tidak mengembalikan nilai atau void
         * Task<T>  > mengembalikan nilai bertipe T
         * 
         * Nama method async wajib diakhiri dengan kata async
         */

        // #1 AWAIT

        Console.WriteLine($"Before Await, thread: {Thread.CurrentThread.ManagedThreadId}");

        string name = await GetEmployeeNameAsync(1);

        // Setelah await, kode bisa dilanjutkan oleh thread yang berbeda
        Console.WriteLine($"After Await, thread: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"Name: {name}");

        // #2 await satu per satu

        Stopwatch stopwatch = Stopwatch.StartNew();

        string employee = await GetEmployeeNameAsync(2);
        int leave = await GetLeaveBalanceAsync(2);

        stopwatch.Stop();
        Console.WriteLine($"Employee Id: {employee} - Leave {leave}, Time: {stopwatch.ElapsedMilliseconds}ms ");

        // #3 Memulai semua task lebih dulu, baru ditunggu bersama
        stopwatch.Restart();

        var employeeTask = GetEmployeeNameAsync(3);
        var leaveTask = GetLeaveBalanceAsync(3);

        await Task.WhenAll(employeeTask, leaveTask); // WhenAll versi async dari waitall

        // await pada task yang sudah selesai langsung mengembalikan hasilnya
        employee = await employeeTask;
        leave = await leaveTask;

        stopwatch.Stop();
        Console.WriteLine($"Employee Id: {employee} - Leave {leave}, Time: {stopwatch.ElapsedMilliseconds}ms ");

        // #4 Exception
        // dengan await, exception asli langsung dikirim tanpa aggregateexception
        try
        {
            await GetLeaveBalanceAsync(-1);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            //throw;
        }
    }

    

    public static async Task<string> GetEmployeeNameAsync(int id)
    {
        await Task.Delay(1000);
        return "Employee";
    }

    public static async Task<int> GetLeaveBalanceAsync(int id)
    {
        await Task.Delay(1000);
        if (id < 0)
            throw new ArgumentException("id tidak boleh negatif");

        return 12;
    }

    public static async Task Cancellation()
    {
        /*
         * Cancellation, membatalkan pekerjaan async yang sedang berjalan
         * Contoh : user menekan tombol batal, atau prosers melebihi batas waktu\
         * 
         * CancellationTokenSource  > Pihak yang meminta pembatalan
         * CancellationToken        > dikirim ke method, dipakai untuk memeriksa permintaan batal
         * 
         * Pembatalan itu bersifat kerja sama, task tidak akan dihentikan paksa
         * Method yang menerimma token harus memeriksa token itu sendiri
         */


        // #1 Cancellation Manual
        CancellationTokenSource cts = new CancellationTokenSource();
        Task payrollTask = ProcessPayrollAsync(10, cts.Token);


        await Task.Delay(1200, cts.Token);
        Console.WriteLine($"Permintaan pembatalan");
        cts.Cancel();

        try
        {
            await payrollTask;
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine($"Prosess payroll dibatalkan: {ex.Message}");
        }

        Console.WriteLine($"Status : {payrollTask.Status}");
        cts.Dispose();
        Console.WriteLine();

        // #2 CancelAfter, batal otomatis setelah batas waktu (timeout)
        CancellationTokenSource cts2 = new CancellationTokenSource();
        cts2.CancelAfter(1200);

        try
        {
            await ProcessPayrollAsync(10, cts2.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"Process payroll melebihi batas waktu 1200ms");
        }
        finally
        {
            cts2.Dispose();
            Console.WriteLine();
        }

        // #3 tidakdibatalkan, prosess berjalan sampai selesai
        CancellationTokenSource cts3 = new CancellationTokenSource();
        await ProcessPayrollAsync(10, cts3.Token);
        Console.WriteLine($"Prosess payroll selesai");
        cts3.Dispose();
    }

    public static async Task ProcessPayrollAsync(int totalEmployees, CancellationToken cancellationToken)
    {
        for (int i = 0; i < totalEmployees; i++)
        {
            // melempar OperationCancelledException jika pembatalan sudah diminta
            cancellationToken.ThrowIfCancellationRequested();

            // Token diteruskan ke method asynchronus lain agar ikut dibatalkan
            await Task.Delay(500, cancellationToken);

            Console.WriteLine($"Payroll Employee Id: {i}");
        }

        
    }
}
