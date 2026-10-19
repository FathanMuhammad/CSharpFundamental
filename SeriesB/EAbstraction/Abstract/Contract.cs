namespace SeriesB.EAbstraction.Abstract;

public class Contract : Employee
{
    private int workDays, dailyRate;
    public Contract(string name, int workDays, int dailyRate) : base(name)
    {
        this.workDays = workDays;
        this.dailyRate = dailyRate;
    }

    protected override int CalculateSalary()
    {
        return dailyRate * workDays;
    }
}
