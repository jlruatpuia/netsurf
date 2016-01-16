using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Netsurf.Codes
{
    public class dbHelper
    {
    }

    public class Customer
    {
        public string CustomerNo { get; set; }

        public string CustomerName { get; set; }

        public string Category { get; set; }
        
        public string Address { get; set; }
        
        public string PinNo { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string PhoneNo { get; set; }
        
        public string Email { get; set; }
        
        public string PlanSelected { get; set; }
        public string Speed { get; set; }
        
        public Customer() { }

    }
}