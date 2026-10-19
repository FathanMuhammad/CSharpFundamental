namespace Practice;

internal class Program
{
    static void Main(string[] args)
    {
        int jumlah = Validation.ReadTotalCustomer();
        Customer[] customers = new Customer[jumlah];

        for (int i = 0; i < jumlah; i++)
        {
            Console.WriteLine($"\n--- Input Data Pelanggan #{i + 1} ---");
            Console.Write("Masukkan Nama Pelanggan: ");
            string name = Console.ReadLine();

            int group = Validation.ReadGroup();
            int initialMeter = Validation.ReadMeter("Meter Awal: ", 0);
            int finalMeter = Validation.ReadMeter("Meter Akhir: ", initialMeter);

            customers[i] = new Customer(name, group, initialMeter, finalMeter);

            // Cetak tagihan pelanggan saat ini
            Report.PrintCustomerBill(customers[i]);
        }

        Features.SearchCustomers(customers);

        // Cetak total tagihan semua pelanggan & pelanggan dengan pemakaian terbesar
        Report.PrintSummary(customers);

        // Proses pembayaran tagihan
        Payment.StartPaymentMenu(customers);
    }
}
