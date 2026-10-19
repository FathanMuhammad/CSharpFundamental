using System;

namespace SeriesB.CInheritence;

// BASE CLASS (Class Induk / Bapak)
public class Person
{
    public string FullName { get; set; }
    public int Age { get; set; }

    // protected set: Hanya bisa diisi di dalam Person atau oleh class anak (Employee)
    public int Id { get; protected set; }
    public string Password { protected get; set; }

    public Person()
    {
    }

    public Person(int id, string fullName, int age)
    {
        Id = id;
        FullName = fullName;
        Age = age;
    }

    // Method bawaan yang dimiliki setiap Person
    public void introduction()
    {
        Console.WriteLine($"[Person] Nama: {FullName} | Umur: {Age} tahun | ID: {Id}");
    }
}
