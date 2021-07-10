using System;
using System.Collections.Generic;
using System.Text;

namespace StockAccountManagement
{
    class StockManagement
    {
        //listing the stock records
        public List<StockRecords> Stocks { get; set; }

        public class StockRecords
        {
            public string Name { get; set; }
            public int Volume { get; set; }
            public int Price { get; set; }
        }
    }
}
