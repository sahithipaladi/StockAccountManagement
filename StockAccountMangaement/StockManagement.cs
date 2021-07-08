using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace StockAccountManagement
{
    class StockManagement
    {
        public void BuyStocks(Customer customerRecords)
        {
            StockManagement management = new StockManagement();
            management.ViewCustomerRecords();
            Console.Write("Enter the Customer ID for Buying Stocks : ");
            string id = Convert.ToString(Console.ReadLine());
            Customer.CustomerRecords marked = new Customer.CustomerRecords();
            foreach (Customer.CustomerRecords customer in customerRecords.CustomerRecordsList)
            {
                if (customer.CustomerId == id)
                {
                    marked = customer;
                    break;
                }
            }
            Console.WriteLine(marked.UserName);
            Stocks stockAccount = JsonConvert.DeserializeObject<Stocks>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement"));
            management.ViewStocks();
            Console.Write("Enter the Name of the Stocks for Buying  : ");
            string buyingStock = Convert.ToString(Console.ReadLine());
            Stocks.StockRecords stockName = new Stocks.StockRecords();
            foreach (Stocks.StockRecords stock in stockAccount.StockRecordsList)
            {
                if (stock.Symbol == buyingStock)
                {
                    stockName = stock;
                    break;
                }
            }
            Console.Write("Enter the Number of Shares you wish to Buy : ");
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            if (numberOfShares <= stockName.NumberOfShares)
            {
                int cost = numberOfShares * stockName.StockPrice;
                if (cost <= marked.Amount)
                {
                    Console.Write("Enter to proceed (Y/N) : ");
                    char proceed = Console.ReadLine()[0];
                    if (proceed == 'Y' || proceed == 'y')
                    {
                        marked.Amount -= cost;
                        stockName.NumberOfShares -= numberOfShares;
                        marked.Shares += numberOfShares;
                        marked.StockDetails[buyingStock] += numberOfShares;
                        Transaction.TransactionRecords newObj = new Transaction.TransactionRecords();
                        newObj.CustomerId = marked.CustomerId;
                        newObj.StockName = stockName.Symbol;
                        newObj.UserName = marked.UserName;
                        newObj.Sell = 0;
                        newObj.Buy = numberOfShares;
                        newObj.ShareValue = (numberOfShares * stockName.StockPrice);
                        Transaction transaction = JsonConvert.DeserializeObject<Transaction>(File.ReadAllText(@"D:\tvstraining\StockAccountManagement\StockAccountManagement\TransactionDetails.json"));
                        transaction.TransactionRecordsList.Add(newObj);
                        File.WriteAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\CustomerDetails.json", JsonConvert.SerializeObject(customerRecords));
                        File.WriteAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\StockDetails.json", JsonConvert.SerializeObject(stockAccount));
                        File.WriteAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\TransactionDetails.json", JsonConvert.SerializeObject(transaction));
                        Console.WriteLine(" Stock is Buyed Sucessfully");
                    }
                    else
                        Console.WriteLine("  Transaction Fail....");
                }
                else
                    Console.WriteLine("\n Balance is Too Low");
            }
            else
                Console.WriteLine("\n Number of Shares of " + stockName.Symbol + " is Too Low");

        }
        public void SellStocks(Customer customerRecords)
        {
            StockManagement management = new StockManagement();
            management.ViewCustomerRecords();
            Console.Write("Enter the Customer ID for Selling Stocks : ");
            string id = Convert.ToString(Console.ReadLine());
            Customer.CustomerRecords marked = new Customer.CustomerRecords();
            foreach (Customer.CustomerRecords customer in customerRecords.CustomerRecordsList)
            {
                if (customer.CustomerId == id)
                {
                    marked = customer;
                    break;
                }
            }
            Console.WriteLine(marked.UserName);
            Stocks stockAccount = JsonConvert.DeserializeObject<Stocks>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\StockDetails.json"));
            management.ViewStocks();
            Console.Write("Enter the Name of the Stocks for Selling  : ");
            string buyingStock = Convert.ToString(Console.ReadLine());
            Stocks.StockRecords stockName = new Stocks.StockRecords();
            foreach (Stocks.StockRecords stock in stockAccount.StockRecordsList)
            {
                if (stock.Symbol == buyingStock)
                {
                    stockName = stock;
                    break;
                }
            }
            Console.Write("Enter the Number of Shares you wish to Sell : ");
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            if (numberOfShares <= marked.StockDetails[buyingStock])
            {
                int cost = numberOfShares * marked.StockDetails[buyingStock];
                if (true)
                {
                    Console.Write("Enter to proceed (Y/N) : ");
                    char proceed = Console.ReadLine()[0];
                    if (proceed == 'Y' || proceed == 'y')
                    {
                        marked.Amount += cost;
                        stockName.NumberOfShares += numberOfShares;
                        marked.Shares -= numberOfShares;
                        marked.StockDetails[buyingStock] -= numberOfShares;
                        Transaction.TransactionRecords newObj = new Transaction.TransactionRecords();
                        newObj.CustomerId = marked.CustomerId;
                        newObj.StockName = stockName.Symbol;
                        newObj.UserName = marked.UserName;
                        newObj.Sell = 0;
                        newObj.Buy = numberOfShares;
                        newObj.ShareValue = (numberOfShares * stockName.StockPrice);
                        Transaction transaction = JsonConvert.DeserializeObject<Transaction>(File.ReadAllText(@"C:\Users\Admin\source\repos\Object Oriented Programs\StockAccountDataProcess\Transaction.json"));
                        transaction.TransactionRecordsList.Add(newObj);
                        File.WriteAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\CustomerDetails.json", JsonConvert.SerializeObject(customerRecords));
                        File.WriteAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\StockDetails.json", JsonConvert.SerializeObject(stockAccount));
                        File.WriteAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\TransactionDetails.json", JsonConvert.SerializeObject(transaction));
                        Console.WriteLine(" Stock is Sold Sucessfully");
                    }
                    else
                        Console.WriteLine("  Transaction Fail....");
                }
            }
            else
                Console.WriteLine("\n Number of Shares is Too High");
        }
        public void ViewStocks()
        {
            Stocks stockAccount = JsonConvert.DeserializeObject<Stocks>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\StockDetails.json"));
            foreach (Stocks.StockRecords stock in stockAccount.StockRecordsList)
            {
                Console.WriteLine("\nStock Name : " + stock.Symbol);
                Console.WriteLine("Number Of Shares : " + stock.NumberOfShares);
                Console.WriteLine("Stock Price : " + stock.StockPrice);
                Console.WriteLine("Stock Value : " + stock.StockValue);
            }
            Console.WriteLine();

        }
        public void ViewCustomerRecords()
        {
            Customer customerRecords = JsonConvert.DeserializeObject<Customer>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\CustomerDetails.json"));
            foreach (Customer.CustomerRecords customer in customerRecords.CustomerRecordsList)
            {
                Console.WriteLine("\nCustomer Id : " + customer.CustomerId);
                Console.WriteLine("UserName : " + customer.UserName);
                Console.WriteLine("Shares : " + customer.Shares);
                Console.WriteLine("Amount : " + customer.Amount);
            }
            Console.WriteLine();

        }
        public void ViewTransactions()
        {
            Console.WriteLine("\n  Transactions ");
            Transaction transaction = JsonConvert.DeserializeObject<Transaction>(File.ReadAllText(@"C:\Users\Sahithi.P\source\repos\StockAccountMangaement\StockAccountMangaement\TransactionDetails.json"));
            foreach (Transaction.TransactionRecords transactionList in transaction.TransactionRecordsList)
            {
                Console.WriteLine("\nCustomer Id : " + transactionList.CustomerId);
                Console.WriteLine("StockName : " + transactionList.StockName);
                Console.WriteLine("UserName :" + transactionList.UserName);
                Console.WriteLine("Sell: " + transactionList.Sell);
                Console.WriteLine("Buys : " + transactionList.Buy);
                Console.WriteLine("ShareValue : " + transactionList.ShareValue);
            }
        }
    }
}

