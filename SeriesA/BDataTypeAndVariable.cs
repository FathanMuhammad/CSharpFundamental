using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace SeriesA;

internal class BDataTypeAndVariable
{
    /* 
    Variable, menampung suatu nilai(value) supaya value bisa digunakkan secara berulang kali
    DataType, format penampung untuk penyimpanan nilai tadi, bisa berisi rentang tertentu atau tipe tertentu 
    Value, Nilai yang dapat dimanipulasi oleh program (dinamis)


    Penulisan Variable:
    Explicit / ditentukan program setelah program
    Format :
    Data Type Variable;
    Variable = Value;

    Implicit / sudah ditentukan compiler
    Format:
    Datatype Variable = Value;
     */

    public static void Variable()
    {
        //Deklarasi
        string fullName;
        char gender;
        int age;
        float gpa;
        bool isActive;

        //Inialisasi
        fullName = "Muhammad Fathan Nuhi";
        gender = 'M';
        age    = 25;
        gpa = 3.8f;
        isActive = true;

        Console.WriteLine(fullName);
        Console.WriteLine(gender);
        Console.WriteLine(age);
        Console.WriteLine(gpa);
        Console.WriteLine(isActive);
    }
    
    //Constant, tampungan yang tidak dapat diubah nilainya ketika ditentukan
    public static void Constant() 
    {
        const float phi = 3.14f;
    }

/*
    Array, dapat menampung beberapa nilai dengan tipe data yang sama
    Array dibagi menjadi 3 = indexed, multidimensional, associate (next)
    Panjang Array bersifat tetap dan harus ditentukan saay init dan tidka bisa ditambah/dikurang.

    Untuk menampilkan array, dimulai dari dengan index 0. (urutan dalam array itu index)
 */

    public static void Array  ()
    {
        string[] studyProgram = {"IT", "CS", "IS", "DS"};
        string[] masterProgram = new string[2];

        masterProgram[0] = "Data Science";
        masterProgram[1] = "Machine Learning";
        //masterProgram[2] = "Arts";

        // multi-dimensional array
        string[,] fullNames = new string[2, 3];
        string[,] masterNames =
        {
            {"Fathan", "Nuhi" },
            {"Hanan", "Nuhi" }
        };

        Console.WriteLine(masterNames[0,0]);
        Console.WriteLine(masterNames[1,1]);
    }
    
}
