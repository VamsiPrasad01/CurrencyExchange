using System;
using System.Collections.Generic;
using ConsoleClient.WholeBackend;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Service1Client();

            try
            {
                Console.WriteLine("🔁 GetExchangeRate for INR:");
                double rate = client.GetExchangeRate("inr");
                Console.WriteLine($"₹INR rate: {rate}\n");

                Console.WriteLine("💰 GetPLNBalance:");
                double pln = client.GetPLNBalance();
                Console.WriteLine($"PLN Balance: {pln}\n");

                Console.WriteLine("💳 Buying 200 PLN worth of INR:");
                string buyResult = client.BuyCurrency("inr", 200);
                Console.WriteLine(buyResult + "\n");

                Console.WriteLine("💰 GetPLNBalance after purchase:");
                pln = client.GetPLNBalance();
                Console.WriteLine($"PLN Balance: {pln}\n");

                Console.WriteLine("💼 Holdings:");
                Dictionary<string, double> holdings = client.GetCurrencyHoldings();
                foreach (var entry in holdings)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value:F2}");
                }
                Console.WriteLine();

                Console.WriteLine("💸 Selling 1000 INR:");
                string sellResult = client.SellCurrency("inr", 1000);
                Console.WriteLine(sellResult + "\n");

                Console.WriteLine("✅ Final PLN Balance:");
                pln = client.GetPLNBalance();
                Console.WriteLine($"PLN Balance: {pln}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            client.Close();
        }
    }
}
