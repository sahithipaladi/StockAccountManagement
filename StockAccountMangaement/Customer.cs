using System;
using System.Collections.Generic;
using System.Text;

namespace StockAccountManagement
{
    class Customer
    {
        public List<CustomerRecords> CustomerRecordsList { get; set; }
        public class CustomerRecords
        {
            public string CustomerId { get; set; }
            public string UserName { get; set; }
            public Dictionary<string, int> StockDetails = new Dictionary<string, int>() { { "HDFCBANK", 0 }, { "UNIONBANK", 0 }, { "CANARABANK", 0 }, { "AXISBANK", 0 }, { "ICICIBANK", 0 } };
            public int Shares { get; set; }
            public int Amount { get; set; }
        }
    }
}