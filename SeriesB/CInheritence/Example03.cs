using System;

namespace SeriesB.CInheritence;

internal class Example03
{
    public void InheritenceExample()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("       DEMO INHERITANCE (PEWARISAN CLASS)        ");
        Console.WriteLine("=================================================");

        // 1. OBJEK BASE CLASS (BAPAK): Person
        // Person HANYA memiliki Nama, Umur, dan Id. TIDAK BISA mengakses Salary!
        Console.WriteLine("1. Objek Person (Base Class / Bapak):");
        Person warga = new Person(1, "Siti Rahma", 20);
        warga.introduction();


        Console.WriteLine("\n-------------------------------------------------");


        // 2. OBJEK DERIVED CLASS (ANAK): Employee
        // Employee mewarisi Nama, Umur, dan Id dari Person, PLUS menambahkan Salary!
        Console.WriteLine("2. Objek Employee (Derived Class yang Mewarisi Person):");
        Employee karyawan = new Employee(101, "Fathan Nuhi", 22, 8_000_000);
        
        // Memanggil method yang membuktikan pewarisan data Person + data Employee
        karyawan.EmployeeIntroduction();

        Console.WriteLine("=================================================\n");
    }
}
