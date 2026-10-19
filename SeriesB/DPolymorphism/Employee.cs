namespace SeriesB.DPolymorphism;

public class Employee : Person
{
    public virtual int Salary
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


    public void setSalary(int salary)
    {
        if (salary <= 0)
        {
            Console.WriteLine("Salary cannot be negative");
        }
        else
        {
            Salary = salary;
        }
    }

    public int AnnualSalary2 => Salary * 12; // Cuma butuh get yang di modif

    // Constructor memanfaatkan constructor milik bapaknya (: base)
    public Employee(int id, string fullName, int age, string password, int salary)
        : base(id, fullName, age, password)
    {
        Salary = salary;
    }

    // Override 1: Memodifikasi method introduction() tanpa parameter
    public override void introduction()
    {
        base.introduction();
        Console.WriteLine($"   └── [Jabatan: Employee] Gaji: Rp {Salary:N0}");
    }

    // Override 2: Memodifikasi method introduction(nickname) dengan parameter
    public override void introduction(string nickname)
    {
        base.introduction(nickname);
        Console.WriteLine($"   └── [Jabatan: Employee] Gaji: Rp {Salary:N0}");
    }

    // Override 3: Mengubah perilaku method Work() khusus untuk Employee
    public override void Work()
    {
        Console.WriteLine($"{FullName} sedang sibuk bekerja menyelesaikan tugas kantor.");
    }

}
