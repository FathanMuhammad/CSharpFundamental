namespace Practice;

public class Validation
{
    public static int ReadTotalCustomer()
    {
        int total;

        while (true)
        {
            Console.Write("Jumlah pelanggan (1-5): ");

            if (int.TryParse(Console.ReadLine(), out total)
                && total >= 1 && total <= 5)
            {
                return total;
            }

            Console.WriteLine("Input harus antara 1-5.");
        }
    }

    public static int ReadGroup()
    {
        int group;

        while (true)
        {
            Console.Write("Golongan (1-3): ");

            if (int.TryParse(Console.ReadLine(), out group)
                && group >= 1 && group <= 3)
            {
                return group;
            }

            Console.WriteLine("Golongan tidak valid.");
        }
    }

    public static int ReadMeter(string name, int minimum)
    {
        int meter;

        while (true)
        {
            Console.Write(name);

            if (int.TryParse(Console.ReadLine(), out meter)
                && meter >= minimum)
            {
                return meter;
            }

            Console.WriteLine(
                $"Meter minimal {minimum}.");
        }
    }
}
