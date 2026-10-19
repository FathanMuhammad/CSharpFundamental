//constructor 1 dan 2 itu method overload
// method introduction itu method overload
namespace SeriesB.DPolymorphism;

public class Person
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Id { get; protected set; }
    public string Password { protected get; set; }
    
    public Person()
    {
    }

    // Constructor lengkap dengan Id
    public Person(int id, string fullName, int age, string password)
    {
        Id = id;
        FullName = fullName;
        Age = age;
        Password = password;
    }

    // Overload constructor tanpa Id (id default 0)
    public Person(string fullName, int age, string password) : this(0, fullName, age, password)
    {
    }

    // Method virtual dasar
    public virtual void introduction()
    {
        Console.WriteLine($"[Person] Nama: {FullName} | Umur: {Age} tahun | ID: {Id}");
    }

    // Method overload: nama sama, beda parameter
    public virtual void introduction(string nickName)
    {
        Console.WriteLine($"[Person] Nama: {FullName} ({nickName}) | Umur: {Age} tahun | ID: {Id}");
    }

    // Contoh Polymorphism nyata: perilaku dasar Person
    public virtual void Work()
    {
        Console.WriteLine($"{FullName} sedang melakukan kegiatan sehari-hari.");
    }
}
