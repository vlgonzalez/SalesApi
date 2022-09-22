using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Sale : Product
    {     
         public int IdSale { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
    }
}