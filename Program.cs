using System;
using System.Collections.Generic;
using System.Numerics;
using static BankTransferConfig;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = BankTransferConfig.LoadConfig();

        config.UbahSatuan();
        Console.WriteLine($"bahasa diubah menjadi: {config.lang}\n");
        int transfer;
        int biaya;
        int total;
        String confirmasi;

        if (config.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer:");
            transfer = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            Console.Write($"Masukkan jumlah uang yang akan di-transfer:");
            transfer = Convert.ToInt32(Console.ReadLine());
        }

        bool low_fee = false;
        if (transfer < config.transfer.threshold)
        {
            biaya = config.transfer.low_fee;
        } else
        {
            biaya = config.transfer.high_fee;
        }


        if (config.lang == "en")
        {
            Console.Write($"Transfer fee =  {biaya}");

            total = transfer + biaya;
            Console.Write($"Total amount =  {total}");
        }
        else
        {
            Console.Write($"Biaya transfer = {biaya}");

            total = transfer + biaya;
            Console.Write($"Total biaya = {total}");
        }


        //if (config.lang == "en")
        //{
        //    Console.Write("Select transfer method:");
        //    transfer = Console.WriteLine($"Select transfer method: {config.lang}\n");
        //}
        //else
        //{
        //    Console.Write("Pilih metode transfer");
        //    transfer = Convert.ToDouble(Console.ReadLine());
        //}

        for (int i = 0; i < config.methods.Count; i++) {
            Console.WriteLine(config.methods[i]);
        }

        if (config.lang == "en")
        {
            Console.WriteLine($" Please type {config.confirmation.en} to confirm the transaction:\n");
            confirmasi = Convert.ToString(Console.ReadLine());
        }
        else
        {
            Console.Write($"Ketik {config.confirmation.en} untuk mengkonfirmasi transaksi:\n");
            confirmasi = Convert.ToString(Console.ReadLine());
        }
        if (config.lang == "en" && confirmasi == config.confirmation.en)
        {
            Console.WriteLine($"The transfer is completed");
            confirmasi = Convert.ToString(Console.ReadLine());
        }
        else if (config.lang == "id" && confirmasi == config.confirmation.en)
        {
            Console.Write($"Proses transfer berhasi");
            confirmasi = Convert.ToString(Console.ReadLine());
        } 
        if (config.lang == "en" && confirmasi != config.confirmation.en)
        {
            Console.WriteLine($"The transfer is completed");
            confirmasi = Convert.ToString(Console.ReadLine());
        }
        else if (config.lang == "id" && confirmasi != config.confirmation.en)
        {
            Console.Write($"Proses transfer berhasi");
            confirmasi = Convert.ToString(Console.ReadLine());
        }
    }
}
