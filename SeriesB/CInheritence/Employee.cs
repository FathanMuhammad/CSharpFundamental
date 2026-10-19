using System;

namespace SeriesB.CInheritence;

// DERIVED CLASS (Class Anak) : Mewarisi (Inherits) seluruh data & method dari Person
public class Employee : Person
{
    // Property tambahan yang HANYA dimiliki oleh Employee (Person tidak punya)
    public int Salary
    {
        get => field;
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Salary cannot be negative");
            }
            else
            {
                field = value;
            }
        }
    }

    // Property kalkulasi khusus Employee
    public int AnnualSalary => Salary * 12;

    // Constructor: Mewarisi pengisian Id, FullName, Age dari Person (: base)
    public Employee(int id, string fullName, int age, int salary)
        : base(id, fullName, age)
    {
        Salary = salary;
    }

    // Method khusus Employee: Membuktikan pewarisan dengan memanggil method bawaan bapak (introduction)
    public void EmployeeIntroduction()
    {
        // 1. Panggil method introduction() warisan dari Person
        introduction();

        // 2. Tambahkan info khusus yang cuma dipunyai Employee
        Console.WriteLine($"   └── [Data Khusus Employee] Gaji Pokok: Rp {Salary:N0} | Gaji Setahun: Rp {AnnualSalary:N0}");
    }
}
