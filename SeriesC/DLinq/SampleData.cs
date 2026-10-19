namespace SeriesC.DLinq;

internal class SampleData
{
    public static List<Department> GetDepartments()
    {
        return new List<Department>
         {
             new (3, "IT"),
             new (1, "HR"),
             new (2, "Finance"),
             new (4, "Marketing"),
         };
    }
    
    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new (1, "Andi", 1, 9000000, 2019),
            new (2, "Fathan", 2, 6500000, 2021),
            new (3, "Cahyo", 1, 12000000, 2017),
            new (4, "Dika", 3, 8000000, 2020),
            new (5, "Fajar", 1, 7000000, 2023),
            new (6, "Eko", 2, 6500000, 2018),
            new (7, "Budi", 3, 10000000, 2016),
        };
    }



}

