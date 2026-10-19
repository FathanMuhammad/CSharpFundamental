namespace SeriesB.EAbstraction.Interface;

public class OvertimeRequest : IAprrovable
{
    private string name;
    private int hours;
    public string Status { get; private set; } = "Pending";

    public OvertimeRequest(string name, int hours)
    {
        this.name = name;
        this.hours = hours;
    }

    public void Approve()
    {
        Status = "Approved";
        Console.WriteLine($"{name} has been Approved for {hours} hours");
    }
}
