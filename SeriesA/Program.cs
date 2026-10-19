namespace SeriesA;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        //BDataTypeAndVariable.Variable();
        //CNumeric.Conversion();
        //DOperator.Arithmatic();
        //DOperator.Assignment();
        //DOperator.Logical();
        //ECondition.ifCondition();
        //ECondition.SwitchCondition

        GMethod.Introduction();
        GMethod.WhoAreYou("Muhammad Fathan Nuhi", "App Dev");

        String fahri = GMethod.FullName("Muhammad Fathan", "Nuhi");
        int age = GMethod.BirthDate(1990, 5, 15);
        Console.WriteLine(fahri);
        Console.WriteLine(age);

        BDataTypeAndVariable.Array();
        Extra();

    }

    public static void Extra()
    {
        var fullName = "Fathan Nuhi";
        var age = 20;
        // cw > tab

        Console.WriteLine($"FullName: {fullName} and Age: {age}");

        // input text
        String text = Console.ReadLine();
        Console.WriteLine(text);

        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(number);
    }
}

