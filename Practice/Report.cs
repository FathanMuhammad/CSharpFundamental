namespace Practice;

public class Report
{
    // Cetak Bill Customer
    public static void PrintCustomerBill(Customer customer)
    {
        int kwhUsage = customer.GetKwhUsage();
        int currentRate = Bill.GetRatesPerKwh(customer.Group);
        float totalBill = customer.GetTotalBill();

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Nama Pelanggan    : {customer.Name}");
        Console.WriteLine($"Golongan Daya     : Golongan {customer.Group}");
        Console.WriteLine($"Meter Awal / Akhir: {customer.InitialMeter} / {customer.FinalMeter}");
        Console.WriteLine($"Penggunaan Listrik: {kwhUsage} kWh");
        Console.WriteLine($"Tarif per kWh     : Rp {currentRate:N0}");
        Console.WriteLine($"Total Tagihan     : Rp {totalBill:N0}");
    }

    public static void PrintSummary(Customer[] customers)
    {
        if (customers == null || customers.Length == 0) return;

        float grandTotalBill = 0;
        Customer highestCustomer = customers[0];

        Console.WriteLine("\n=============================================");
        Console.WriteLine("         REKAP TAGIHAN SELURUH PELANGGAN     ");
        Console.WriteLine("=============================================");

        foreach (var customer in customers)
        {
            int kwhUsage = customer.GetKwhUsage();
            float totalBill = customer.GetTotalBill();

            grandTotalBill += totalBill;

            if (kwhUsage > highestCustomer.GetKwhUsage())
            {
                highestCustomer = customer;
            }
        }

        Console.WriteLine($"Jumlah Pelanggan             : {customers.Length}");
        Console.WriteLine($"Total Tagihan Semua Pelanggan: Rp {grandTotalBill:N0}");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Pelanggan dengan Pemakaian Terbesar:");
        Console.WriteLine($"- Nama        : {highestCustomer.Name}");
        Console.WriteLine($"- Pemakaian   : {highestCustomer.GetKwhUsage()} kWh");
        Console.WriteLine($"- Total Tagih : Rp {highestCustomer.GetTotalBill():N0}");
        Console.WriteLine("=============================================\n");
    }
}
