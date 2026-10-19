namespace SeriesB.EAbstraction.Abstract;

public class Permanent : Employee
{
    private int baseSalary, allowance;
    public Permanent(string name, int baseSalary, int allowance) : base(name)
    {
        this.baseSalary = baseSalary;
        this.allowance = allowance;
    }

    protected override int CalculateSalary()
    {
        return baseSalary + allowance;
    }
}
