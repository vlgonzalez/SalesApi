using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string? CPF { get; set; }
        public string? SellerName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}