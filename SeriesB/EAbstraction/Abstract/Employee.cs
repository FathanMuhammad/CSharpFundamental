namespace SeriesB.EAbstraction.Abstract;

// Abstract Class -> Jenisnya adalah partial abstraction, isinya bisa method biasa, method tanpa implement dan atribute
// Abstract Class tidak bisa diinstance sebagai object. hanya bisa diwariskan
// 
public abstract class Employee
{
    // Atribute
    public string name;

    public Employee(string name)
    {
        this.name = name;
    }

    // Method biasa
    public void ShowPayslip()
    {
        Console.WriteLine($"Name : {name}, Gaji : {CalculateSalary():N0}");
    }

    // Abstract Method
    protected abstract int CalculateSalary();
}
