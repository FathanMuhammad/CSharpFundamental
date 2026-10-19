namespace Practice;

public class Features
{
    public static void SearchCustomers(Customer[] customers)
    {
        while (true)
        {
            Console.Write("\nCari pelanggan? (y/n): ");
            string answer = Console.ReadLine() ?? "";

            if (!answer.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            Console.Write("Masukkan nama: ");
            string keyword = Console.ReadLine() ?? "";

            bool found = false;

            foreach (Customer customer in customers)
            {
                if (customer.Name.Contains(
                        keyword,
                        StringComparison.OrdinalIgnoreCase))
                {
                    Report.PrintCustomerBill(customer);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Pelanggan tidak ditemukan.");
            }

            Console.Write("\nCari pelanggan lagi? (y/n): ");
            answer = Console.ReadLine() ?? "";

            if (!answer.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}