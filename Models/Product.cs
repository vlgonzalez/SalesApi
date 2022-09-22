using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Product : Seller
    {
        public int IdProduct { get; set; }
        public string? ProductName { get; set; }

    }
}