using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesB.DPolymorphism;

public class Manager : Employee
{
    // Urutan parameter dicocokkan dengan constructor Employee: password dulu, baru salary
    public Manager(int id, string fullName, int age, string password, int salary)
        : base(id, fullName, age, password, salary)
    {
    }

    // Override property Salary: Manager otomatis dapat gaji 2x lipat
    public override int Salary
    {
        get => base.Salary;
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Salary must be greater than zero");
            }
            else
            {
                base.Salary = value * 2;
            }
        }
    }

    // Override method Work khusus untuk Manager
    public override void Work()
    {
        Console.WriteLine($"{FullName} (Manager) sedang memimpin meeting dan mengawasi project tim.");
    }
}
