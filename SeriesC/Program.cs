using SeriesC.AExceptionHandling;
using SeriesC.BCollection;
using SeriesC.CGenerics;
using SeriesC.DLinq;
using SeriesC.EAsynchronus;

namespace SeriesC;

internal class Program
{
    static void Main(string[] args)
    {
        //ExceptionHandling.TryCatchFinally();
        //Console.WriteLine("==========");
        //ExceptionHandling.ThrowKeyword();
        //Collection.ListCollection();

        //Employee<string> herul = new Employee<string>();
        //Employee<int> rifqi = new Employee<int>();

        //herul.Id = "x123";
        //herul.FullName = "Herul Syahwandi S";
        //herul.Salary = 1000;
        //herul.Job = "Junior Programmer";

        //rifqi.Id = 9990;
        //rifqi.FullName = "Herul Syahwandi S";
        //rifqi.Salary = 1000;
        //rifqi.Job = "Junior Programmer";

        //herul.Introduction();
        //rifqi.Introduction();


        // --- LINQ --- //
        //LinqQuery.Grouping();

        //Console.WriteLine("============");
        //LinqQuery.Joining();

        //Console.WriteLine("=====Group Join======");
        //LinqQuery.GroupingJoining();

        //Multithread.ConcurrencyAndParallelism();

        //Asynchronus.TaskClass();
        Asynchronus.AsyncAwait().Wait();
        Asynchronus.Cancellation().Wait();
    }
}
