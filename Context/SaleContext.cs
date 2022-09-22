using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context
{
    public class SaleContext :DbContext
    {
    public SaleContext(DbContextOptions<SaleContext> options) :base(options)
        {

        }

         public DbSet<Sale> Sales {get; set;}
     
         public DbSet<Seller> Sellers {get; set;}
        
        public DbSet<Product>? Products {get; set;}
      
    }
}