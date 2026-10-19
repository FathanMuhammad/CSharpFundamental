namespace SeriesB.EAbstraction.Interface;

public class LeaveRequest : IAprrovable, ICancelable
{
    private string name;
    private int days;

    public string Status { get; private set; } = "Pending";

    public LeaveRequest(string name, int days)
    {
        this.name = name;
        this.days = days;
    }

    public void Approve()
    {
        Status = "Approved";
        Console.WriteLine($"{name} has been Approved for {days} days");
    }

    public void Cancel()
    {
        Status = "Canceled";
        Console.WriteLine($"{name} has been Canceled for {days} days");
    }
}
