namespace SeriesB.BEncapsulation;

public class Example02
{
    public void EncapsulationExample()
    {
        Employee fathan = new Employee(12345);
        fathan.FullName = "Fathan Nuhi";
        fathan.Age = 21;
        //fathan.id = 12123;
        fathan.Password = "1234" ;

        fathan.setSalary(1000000);

        //fathan.introduction();
        // Accessing private member id through public method GetId()
        Console.WriteLine(fathan.FullName);
        Console.WriteLine(fathan.Age);
        Console.WriteLine(fathan.Id);
        Console.WriteLine("==========");
        Console.WriteLine(fathan.Salary);
        Console.WriteLine(fathan.AnnualSalary);
        Console.WriteLine(fathan.AnnualSalary2);
    }

}
