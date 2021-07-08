using System;
using Newtonsoft.Json;
using System.IO;

namespace StockAccountManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome To Stock Amount Management\n");
            Console.WriteLine(" Customer Records\n");
            bool alive = true;
            while (alive)
            {
                Customer customerRecords = JsonConvert.DeserializeObject<Customer>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\CustomerDetails.json"));
                Stocks stockAccount = JsonConvert.DeserializeObject<Stocks>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\StockDetails.json"));
                Console.WriteLine("\n1.Buy Stocks\n2.Sell Stocks\n3.View Stocks\n4.View Customer Records\n5.View Transaction Details\n6.Exit");
                Console.WriteLine("Enter your option:");
                int option = Convert.ToInt32(Console.ReadLine());
                StockManagement stockManagement = new StockManagement();
                switch (option)
                {
                    case 1:
                        stockManagement.BuyStocks(customerRecords);
                        break;
                    case 2:
                        stockManagement.SellStocks(customerRecords);
                        break;
                    case 3:
                        stockManagement.ViewStocks();
                        break;
                    case 4:
                        stockManagement.ViewCustomerRecords();
                        break;
                    case 5:
                        stockManagement.ViewTransactions();
                        break;
                    case 6:
                        alive = false;
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Output!!");
                        break;

                }
            }
            Console.Read();
        }
    }
}