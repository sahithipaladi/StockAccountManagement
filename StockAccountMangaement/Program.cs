using System;

namespace StockAccountManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating object
            Stocks stock = new Stocks();
            stock.Stock_Management();
            stock.CalculateEachStockValue();
            stock.CalculateTotalStockValue();
            Console.Read();
        }
    }
}