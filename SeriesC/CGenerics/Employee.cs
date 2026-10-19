using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesC.CGenerics;

public class Employee<TId>
{
    public TId Id { get; set; }
    public string FullName { get; set; }
    public decimal Salary { get; set; }
    public string Job { get; set; }

    public void Introduction(TId contoh)
    {
        Console.WriteLine("========");
        Console.WriteLine("ID :"+ Id);
        Console.WriteLine("NAME :"+ FullName);
        Console.WriteLine("SALARY :"+ Salary);
        Console.WriteLine("JOB :"+ Job);
        Console.WriteLine(contoh);
    }

    //public int CalculateTax()
    //{
    //    decimal tax = 2;

    //    return Salary*tax;
    
}
