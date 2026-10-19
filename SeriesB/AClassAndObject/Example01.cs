namespace SeriesB.BEncapsulation;

internal class Example01
{
    public void ClassObjectExample()
    {
        Person fathan = new Person(); // person() adalah constructor dari class Person, syaratnya adalah namanya harus sama
                                      // dngn kelas. berguna untuk instace object dari class Person, dipanggil setiap kali
                                      // membuat object dan tidakbisa dipanggil berulang di object yang sama

        fathan.name = "Fathan Nuhi";
        fathan.age = 22;
        fathan.Introduction();

        Person violet = new Person();
        violet.name = "Violet";
        violet.age = 22;
        violet.Introduction();

        Person nuhi = new Person("Nuhi", 22);
        nuhi.Introduction();

        Console.WriteLine(nuhi.name);
        Console.WriteLine(nuhi.age);

        //Person.count = 50;

        // Static member dipanggil lewat nama class, bukan lewat nama object
        Console.WriteLine("Count : " + Person.count);
        Console.WriteLine("Count : " + fathan.PlusOne());
    }
}
