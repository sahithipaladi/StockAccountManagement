using System;
using System.Collections.Generic;
using System.Text;

namespace StockAccountManagement
{
    class Transaction
    {
        public List<TransactionRecords> TransactionRecordsList { get; set; }
        public class TransactionRecords
        {
            public string CustomerId { get; set; }
            public string UserName { get; set; }
            public string StockName { get; set; }
            public int Buy { get; set; }
            public int Sell { get; set; }
            public int ShareValue { get; set; }
        }
    }
}