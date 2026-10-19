namespace SeriesB.BEncapsulation;

internal class Person
{
    // Atribute or property (data), milik tiap object // tadi atribute apa maksudnya mas
    public string name;
    public int age;

    // Static, milik class > hanya ada satu dan dipakai bersama oleh semua object;
    // biar keliatan beda itu letakkan count
    // biasanya pake static itu di suatu hal yang konstant
    // 
    public static int count;

    // Constructor, method khusus yang dipanggil setiap kali membuat object dari class
    public Person()
    {
        count++;
        Console.WriteLine("Creating a new person");
    }

    // Beda constructor, bisa ada lebih dari satu constructor di class yang sama, tapi harus berbeda parameternya
    public Person(string name, int age)
    {
        count++;
        this.name = name;
        this.age = age;
        Console.WriteLine("Creating a new person with name and age");
    }




    // Behavior or method, suatu perilaku atau tingkah laku yang dapat dilakukan oleh object
    public void Introduction()
    {
        Console.WriteLine($"Hi, my name is {name} and I am {age} years old.");
    }

    public int PlusOne()
    {
        count++;
        return count;
    }
    

}
