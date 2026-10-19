using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesA;

// method, membungkus statements (beberapa kode). satu method hanya punya 1 tujuan.

// method dibagi 2:
// void, tidak mengembalikan nilai/value : void selalu digunakkan untuk mencetak
// non-void, mengembalikan nilai,value : selain Print, jadi tidak boleh ada consolewriteline

// MEthod boleh menerima masukan atau parameter
// Jika menerima namanya parameter, jika memberi namanya arguments
internal class GMethod
{
    public static void Introduction ()
    {
        Console.WriteLine("Full Name: Muhammad Fathan Nuhi");
        Console.WriteLine("Job Position: Application Developer");
    }

    public static void WhoAreYou(string fullname, string Position)
    {
        Console.WriteLine("Full Name: " + fullname);
        Console.WriteLine("Job Position: " + Position);
    }

    public static string FullName(string FirstName, string LastName)
    {
        return FirstName + " " +LastName;
    }
    
    public static int BirthDate(int year, int month, int date)
    {
        DateTime birthDate = new DateTime(year, month, date);
        DateTime now = DateTime.Now;
        return now.Year - birthDate.Year;
    }   


}
