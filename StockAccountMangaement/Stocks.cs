using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace StockAccountManagement
{
    class Stocks
    {
        StockManagement manage = JsonConvert.DeserializeObject<StockManagement>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\StocksReports.json"));

        //Printing Stock Report
        public void Stock_Management()
        {
            string stockRecord = string.Empty;
            Console.WriteLine("--------------------Dispaly Stock Report---------------------");
            foreach (StockManagement.StockRecords stock in manage.Stocks)
            {
                Console.WriteLine("Name of the stock : " + stock.Name);
                Console.WriteLine("Total stocks of a company : " + stock.Volume);
                Console.WriteLine("Stock Price : " + stock.Price + "\n");
                //stockRecord += "\nName of the stock: " + stock.Name + "\nTotal stocks of a company: " + stock.Volume + "\nStock Price: " + stock.Price + "\n";
            }
            Console.WriteLine(stockRecord);
        }

        //Calculating each stock value
        public void CalculateEachStockValue()
        {
            double value = 0, price = 0;
            int numOfShare = 0;
            Console.WriteLine("-----------------------Calculate each stock value-----------------------");
            for (int i = 0; i < manage.Stocks.Count; i++)
            {
                var jsonObject = manage.Stocks[i];
                price = jsonObject.Price;
                numOfShare = jsonObject.Volume;
                value = price * numOfShare;
                Console.WriteLine("Value of the particular stock for " + jsonObject.Name + " is " + value + "\n");
            }
        }

        //Calculating total stock value
        public void CalculateTotalStockValue()
        {
            double value = 0, price = 0, totalValue = 0;
            int numOfShare = 0;
            Console.WriteLine("\n-----------------------Calculate total stock value-----------------------");
            for (int i = 0; i < manage.Stocks.Count; i++)
            {
                var jsonObject = manage.Stocks[i];
                price = jsonObject.Price;
                numOfShare = jsonObject.Volume;
                value = price * numOfShare;
                totalValue += value;
            }
            Console.WriteLine("Value of the Total stock is " + totalValue + "\n");
        }
    }
}
