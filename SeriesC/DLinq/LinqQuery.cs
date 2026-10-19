using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace SeriesC.DLinq;

public class LinqQuery
{
    public static void Introduction()
    {
        var employees = SampleData.GetEmployees();

        // Tanpa LINQ
        var names1 = new List<string>();
        foreach (var employee in employees)
        {
            if (employee.Salary > 8000000)
            {
                names1.Add(employee.Name);
            }
        }
        Console.WriteLine($"Tanpa LINQ: {names1.Count} employees");




        // Dengan LINQ
        var names2 = employees
            .Where(e => e.Salary > 8000000)
            .Select(e => e.Name)
            .ToList();
        Console.WriteLine($"Dengan LINQ: {names2.Count} employees");

        // LINQ pada colection lain
        int[] numbers = { 5, 7, 8, 9, 10, 11, };
        Console.WriteLine($"Array, jumlah genap: {numbers.Where(n => n % 2 == 0).Count()}");
        Console.WriteLine($"Array2, jumlah genap: {numbers.Count(n => n % 2 == 0)}");


        // Deffered Function
        // Query tidak dijalankan saat ditulis, tetapi hasilnya dipakai
        // (foreach, count, ToList, dsb)
        List<int> scores = new List<int> { 60, 90, 85 };

        var passed = scores.Where(s => s >= 75); // belum dijalankan
        scores.Add(100);
        Console.WriteLine($"Lulus : {passed.Count()}"); // hasilnya 3 bukan 2 dimana nilai 100 ikut terhitung



        var passedList = scores.Where(s => s >= 75).ToList();
        scores.Add(95);
        Console.WriteLine($"Lulus (ToList) : {passedList.Count}"); // ttetap 3, nilai 95 tidak ikut terhitung karena sudah dijalankan saat ToList dipanggil
        Console.WriteLine($"Lulus (Query) : {passed.Count()}"); // jadi 4, nilai 95 terhitung
    }


    public static void Transformation()
    {
        var employees = SampleData.GetEmployees();

        //select, mengambil satu property
        var names = employees.Select(e => e.Name);
        Console.WriteLine($"Nama : {string.Join(", ", names)}"); // String.Join menggabungkan data dengan pemisah

        //select, dengan perhitungan
        var annualSalaries = employees.Select(e => e.Salary * 12);
        Console.WriteLine($"Gaji Tahunan Pertama: {annualSalaries.First()}");

        //select, anonymous type, jika perlu untuk beberapa prop
        var summaries = employees.Select(e => new
        {
            e.Name,                                         // Nama property mengikuti asalnya
            AnnualSalary = e.Salary * 12,
            YearOfService = DateTime.Now.Year - e.JoinYear
        }).ToList();

        foreach (var employee in summaries)
        {
            Console.WriteLine($" {employee.Name} : {employee.AnnualSalary} : {employee.YearOfService}");
        }

    }

    public static void Grouping()
    {
        var employees = SampleData.GetEmployees();

        //var groups = employees.GroupBy(e => e.DepartmentId).Where(g => g.Count() > 2); // Jika ingin kondisi where, bisa ditambahkan setelah GroupBy
        var groups = employees.GroupBy(e => e.DepartmentId);

        foreach (var group in groups)
        {
            Console.WriteLine($"Department {group.Key}: {group.Count()} Karyawan");
            foreach (var employee in group)
            {
                Console.WriteLine($"{employee.Name}");
            }
        }
    }

    public static void Joining()
    {
        var employees = SampleData.GetEmployees();
        var departments = SampleData.GetDepartments();

        // Join employees dengan departments
        var joined = employees.Join(
            departments,
            e => e.DepartmentId,  // Key dari Employee
            d => d.Id,             // Key dari Department
            (e, d) => new          // Hasil Join: anonymous type
            {
                EmployeeId = e.Id,
                Name = e.Name,
                Department = d.Name
            }
        );

        // Menampilkan hasil Join
        foreach (var employee in joined)
        {
            Console.WriteLine(
                $"{employee.EmployeeId} : {employee.Name} - {employee.Department}"
            );
        }
    }

   // Tugas Grouping + join, total gaji per nama Department
   public static void GroupingJoining()
    {
        var employees = SampleData.GetEmployees();
        var departments = SampleData.GetDepartments();

        // 1. Join employees dengan departments
        var joined = employees.Join(
            departments,
            e => e.DepartmentId,      // Key dari Employee
            d => d.Id,              // Key dari Department
            (e, d) => new
            {
                EmployeeId = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Department = d.Name
            }
        );

        // 2. Group berdasarkan nama Department
        var groups = joined.GroupBy(e => e.Department);

        // 3. Tampilkan jumlah karyawan dan total gaji setiap Department
        foreach (var group in groups)
        {
            Console.WriteLine(
                $"Department {group.Key}: " +
                $"{group.Count()} Karyawan, " +
                $"Total Gaji {group.Sum(e => e.Salary):N0}"
            );
            foreach (var employee in group)
            {
                Console.WriteLine($"{employee.Name}");
            }
        }
    }
}

