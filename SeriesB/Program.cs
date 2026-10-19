//using SeriesB.BEncapsulation;
//using SeriesB.CInheritence;
//using SeriesB.DPolymorphism;
//using SeriesB.EAbstraction;
using SeriesB.EAbstraction.Abstract;
using SeriesB.EAbstraction.Interface;
//using System.Diagnostics.Contracts;

namespace SeriesB;

internal class Program
{
    static void Main(string[] args)
    {
        //// Demo 1: INHERITANCE (Folder C)
        //Example03 example03 = new Example03();
        //example03.InheritenceExample();

        // Demo 2: POLYMORPHISM (Folder D)
        // Example04 example04 = new Example04(); 
        // example04.PolymorphismExample();


        //Employee fathan = new Contract("fathan", 20, 150000);
        //fathan.ShowPayslip();

        //Employee fathan2 = new Permanent("fathan2", 8000000, 500000);
        //fathan2.ShowPayslip();

        // Membuat objek request
        OvertimeRequest overtime = new OvertimeRequest("Fathan", 3);

        LeaveRequest leave = new LeaveRequest("Fathan", 2);

        // Menampilkan status awal
        Console.WriteLine("=== Initial Status ===");
        Console.WriteLine($"Overtime: {overtime.Status}");
        Console.WriteLine($"Leave: {leave.Status}");

        // Approve overtime
        Console.WriteLine("\n=== Approve Overtime ===");
        overtime.Approve();

        // Approve leave
        Console.WriteLine("\n=== Approve Leave ===");
        leave.Approve();

        // Cancel leave
        Console.WriteLine("\n=== Cancel Leave ===");
        leave.Cancel();

        // Menampilkan status akhir
        Console.WriteLine("\n=== Final Status ===");
        Console.WriteLine($"Overtime: {overtime.Status}");
        Console.WriteLine($"Leave: {leave.Status}");

    }
}
