namespace SeriesB.DPolymorphism;

internal class Example04
{
    public void PolymorphismExample()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("1. METHOD OVERLOADING (Nama Sama, Beda Parameter)");
        Console.WriteLine("=================================================");
        Person fathan = new Person(1, "Fathan Nuhi", 22, "pass123");
        
        fathan.introduction();              // Memanggil overload 1
        fathan.introduction("Nuhi");        // Memanggil overload 2


        Console.WriteLine("\n=================================================");
        Console.WriteLine("2. METHOD OVERRIDING (Anak Memodifikasi Bapak)");
        Console.WriteLine("=================================================");
        Employee budi = new Employee(101, "Budi Santoso", 28, "pass456", 8_500_000);
        
        budi.introduction("Budi");          // Memanggil versi Employee yang sudah di-override


        Console.WriteLine("\n=================================================");
        Console.WriteLine("3. POLIMORFISME SEJATI: SATU TIPE, BANYAK BENTUK");
        Console.WriteLine("=================================================");
        // Array bertipe Person, tapi bisa menampung Person, Employee, hingga Manager!
        Person[] daftarWarga = new Person[]
        {
            new Person(2, "Siti Rahma", 20, "pass789"),
            new Employee(102, "Ahmad Dani", 30, "pass999", 10_000_000),
            new Manager(201, "Pak Hendra", 42, "bos123", 15_000_000) // Gaji 15jt otomatis jadi 30jt
        };

        foreach (Person p in daftarWarga)
        {
            // C# otomatis memanggil perilaku sesuai objek aslinya di memori!
            p.introduction();
            p.Work();
            Console.WriteLine();
        }
    }
}
