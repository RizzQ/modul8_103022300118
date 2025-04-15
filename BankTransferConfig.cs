using System;
using System.IO;
using System.Text.Json;

public class BankTransferConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; } 
    }
    public List<String> methods { get; set; }
    public Confirmation confirmation { get; set; }
    public class Confirmation
    {
        public String en { get; set; }
        public String id { get; set; }
    }

    private const string configPath = "bank_transfer_config.json";

    //private static BankTransferConfig defaultConfig = new BankTransferConfig
    //{
    //    lang = "en",
    //    //transfer.threshold = 25000000,
    //    //methods = [ "RTO", "(real-time)", "SKN", "RTGS", "BI", "FAST" ],
    //    //confirmation = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
    //};

    public static BankTransferConfig LoadConfig()
    {
        //if (!File.Exists(configPath))
        //{
        //    SaveConfig(defaultConfig);
        //    return defaultonfig;
        //}

        string json = File.ReadAllText(configPath);
        return JsonSerializer.Deserialize<BankTransferConfig>(json);
    }

    public static void SaveConfig(BankTransferConfig config)
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(configPath, json);
    }

    public void UbahSatuan()
    {
        if (lang.ToLower() == "en")
        {
            lang = "en";
        }
        else
        {
            lang = "id";
        }

        SaveConfig(this); 
    }
}
