using System;
using System.Collections.Generic;
using System.Text;

namespace StockAccountManagement
{
    class StockManagement
    {
        public List<StockRecords> Stocks { get; set; }

        public class StockRecords
        {
            public string Name { get; set; }
            public int Volume { get; set; }
            public int Price { get; set; }
        }
    }
}
