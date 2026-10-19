namespace SeriesB.BEncapsulation;


/*
 * Encapsulation, menyembunyikan data didalam class dan hanya membuka jalur yang dikontrol oleh class itu sendiri
 * melalui access modifier, tujuannya supaya data tidak bisa diubah seenaknya oleh object lain, tapi harus melalui method yang disediakan oleh class itu sendiri
 * 
 * Access modifier, ada 4 jenis, yaitu:
 * public > bisa diakses dari mana saja, baik dari class yang sama maupun class lain
 * private > hanya bisa diakses dari class yang sama
 * internal > hanya bisa diakses dari (project) class yang sama dan class lain yang berada dalam assembly yang sama.
 * protected > hanya bisa diakses dari class yang sama dan class turunan (inheritance).
  
 */
public class Employee
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Id { get; private set; }
    public string Password { private get; set; }
    //private int salary;
    public int Salary { get; set; }


    public void setSalary(int salary)
    {
        if(salary <= 0)
        {
            Console.WriteLine("Salary cannot be negative");
        }
        else
        {
            Salary = salary;
        }
    }

    public int AnnualSalary // butuh get yang di modif dan set default
    {
        get
        {
            return Salary * 12;
        }
        set;
    }

    public int AnnualSalary2 => Salary * 12; // Cuma butuh get yang di modif

    public Employee (int id)
    { 
        Id = id; 
    }

    public void introduction()
    {
        Console.WriteLine($"Employee FullName {FullName} Employee Is {Age} years old. Employee Id is {Id}");
        Console.WriteLine("Password : " + Password);
        Console.WriteLine("Salary : " + Salary);
    }
}
