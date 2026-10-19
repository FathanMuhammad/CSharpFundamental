using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesC.BCollection;

internal class Collection
{
    public static void ListCollection()
    {
        //Membuat list kosong
        List<string> courses = new List<string>();

        //Membua list langsung dengan isinya
        List<int> scores = new List<int> { 80, 65, 90};

        // Tambah data
        courses.Add("SQL Server"); // di akhir
        courses.Add("React TypeScript");
        courses.Add("C#");
        courses.Insert(0, "Class Diagram"); // di index tertentu


        // akses data
        Console.WriteLine("Index :" + courses[0]);

        // modifikasi data
        courses[3] = "C# Fundamental";

        // jumlah data
        Console.WriteLine("TOtal: "+ courses.Count);

        // Cari Data
        Console.WriteLine("Ada C#? " + courses.Contains("C# Fundamental"));
        Console.WriteLine("Lokasi Index C#? " + courses.IndexOf("C# Fundamental"));

        Console.WriteLine("=========");
        foreach (string course in courses)
        {
            Console.WriteLine("Course :" + course);
        }

        Console.WriteLine("=============");

        // Urutan data
        scores.Sort();
        Console.WriteLine("Nilai terendah: " + scores[0]);

        // hapus semua data
        courses.Clear();
        Console.WriteLine("Jumlah courses: " + courses.Count);

    }
}
