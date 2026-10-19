namespace Practice;

public class Payment
{

    // disini ada 3 method 
    public static void StartPaymentMenu(Customer[] customers)
    {
        Console.WriteLine("\n=============================================");
        Console.WriteLine("         PROSES PEMBAYARAN TAGIHAN           ");
        Console.WriteLine("=============================================");

        while (true)
        {
            // Tampilkan daftar pelanggan yang belum bayar
            int unpaidCount = 0;
            Console.WriteLine("\nPelanggan yang belum bayar:");

            for (int i = 0; i < customers.Length; i++)
            {
                if (!customers[i].IsPaid)
                {
                    unpaidCount++;
                    Console.WriteLine($"  {i + 1}. {customers[i].Name,-15} - Rp {customers[i].GetTotalBill():N0}");
                }
            }

            // Jika semua sudah lunas
            if (unpaidCount == 0)
            {
                Console.WriteLine("  Semua pelanggan sudah lunas!");
                break;
            }

            // Pilih pelanggan
            Console.Write("\nPilih nomor pelanggan (0 untuk selesai): ");

            if (!int.TryParse(Console.ReadLine(), out int pilihan))
            {
                Console.WriteLine("Input tidak valid.");
                continue;
            }

            if (pilihan == 0) break;

            if (pilihan < 1 || pilihan > customers.Length)
            {
                Console.WriteLine("Nomor pelanggan tidak valid.");
                continue;
            }

            Customer selected = customers[pilihan - 1];

            if (selected.IsPaid)
            {
                Console.WriteLine($"{selected.Name} sudah lunas!");
                continue;
            }

            // Proses pembayaran
            ProcessPayment(selected);
        }

        // Cetak status pembayaran akhir
        PrintPaymentStatus(customers);
    }

    public static void ProcessPayment(Customer customer)
    {
        //ambil total tagihan
        float totalBill = customer.GetTotalBill();
        Console.WriteLine($"\nTagihan {customer.Name}: Rp {totalBill:N0}");

        while (true)
        {
            Console.Write("Masukkan jumlah bayar: Rp ");

            if (!int.TryParse(Console.ReadLine(), out int uangBayar) || uangBayar <= 0)
            {
                Console.WriteLine("Jumlah bayar tidak valid.");
                continue;
            }

            if (uangBayar < totalBill)
            {
                float kurang = totalBill - uangBayar;
                Console.WriteLine($"Uang tidak cukup! Kurang Rp {kurang:N0}");
                continue;
            }

            // Pembayaran berhasil
            float kembalian = uangBayar - totalBill;
            customer.IsPaid = true;

            Console.WriteLine("Pembayaran berhasil!");
            if (kembalian > 0)
            {
                Console.WriteLine($"Kembalian: Rp {kembalian:N0}");
            }
            break;
        }
    }

    public static void PrintPaymentStatus(Customer[] customers)
    {
        float totalTerbayar = 0;
        float totalBelumBayar = 0;

        Console.WriteLine("\n============ STATUS PEMBAYARAN =============");

        foreach (var customer in customers)
        {
            float bill = customer.GetTotalBill();
            string status;

            if (customer.IsPaid)
            {
                status = "LUNAS";
                totalTerbayar += bill;
            }
            else
            {
                status = "BELUM BAYAR";
                totalBelumBayar += bill;
            }

            Console.WriteLine($"  {customer.Name,-15} : {status}");
        }

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"  Total Terbayar    : Rp {totalTerbayar:N0}");
        Console.WriteLine($"  Total Belum Bayar : Rp {totalBelumBayar:N0}");
        Console.WriteLine("=============================================\n");
    }
}
