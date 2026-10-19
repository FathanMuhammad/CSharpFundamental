namespace SeriesC.DLinq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public int Salary { get; set; }
    public int JoinYear { get; set; }

    public Employee(int id, string name, int departmentId, int salary, int joinYear)
    {
        Id = id;
        Name = name;
        DepartmentId = departmentId;
        Salary = salary;
        JoinYear = joinYear;
    }
}
