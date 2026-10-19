namespace Practice;

public class Customer
{
    public string Name { get; set; }
    public int Group { get; set; }
    public int InitialMeter { get; set; }
    public int FinalMeter { get; set; }
    public bool IsPaid { get; set; } // untuk ngelacak status pembayarannya

    public Customer(string name, int group, int initialMeter, int finalMeter)
    {
        Name = name;
        Group = group;
        InitialMeter = initialMeter;
        FinalMeter = finalMeter;
    }

    public int GetKwhUsage()  
    {
        return FinalMeter - InitialMeter;
    }

    public float GetTotalBill() 
    {
        int rate = Bill.GetRatesPerKwh(Group);
        int bill = GetKwhUsage() * rate;
        return Bill.TotalBill(bill);
    }
}
