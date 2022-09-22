using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route ("sales")]
    public class SaleController : ControllerBase
    {
     private readonly SaleContext _context;

    public SaleController(SaleContext context)
    {
      _context = context;
    }
    
    [HttpPost("Comprar")]
    public IActionResult Create (Product product)
    {

        if(product.ProductName == null)
        return BadRequest("Adicione pelo menos um produto" );
          
         var sale = new Sale(){
         Date = DateTime.Now,
         CPF = product.CPF,
         SellerName = product.SellerName,
         Email = product.Email,
         PhoneNumber = product.PhoneNumber,
         IdProduct = product.IdProduct,
         ProductName = product.ProductName,
         Status = "Aguardando pagamento",
        };
        
        _context.Add(sale);
        _context.SaveChanges();

         return Ok($"sua compara ID {sale.Id}, adiciono com sucesso, {sale.Status}");
        }
        
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
        {
            var sale = _context.Sales.Find(id);
            if(sale == null)
            return NotFound();
            return Ok(sale);
        }
    [HttpPatch("{id}")]
      public IActionResult UpdateStatus(int id, string status)
      {
          var saleDataBase = _context.Sales.Find(id);
          if(saleDataBase == null)
            return NotFound();

          List<string> listStatus = new List<string>()
            {
                "Aguardando pagamento",
                "Pagamento aprovado",
                "Enviado para transportadora",
                "Entregue",
                "Cancelada"
            };

            if(listStatus.IndexOf(saleDataBase.Status) == 0 && listStatus.IndexOf(status) ==1 || listStatus.IndexOf(status) ==4)
            saleDataBase.Status = status;

            if(listStatus.IndexOf(saleDataBase.Status) == 1 && listStatus.IndexOf(status) ==4 || listStatus.IndexOf(status) ==2)
            saleDataBase.Status = status;

            if(listStatus.IndexOf(saleDataBase.Status) == 2 && listStatus.IndexOf(status) ==3 )
            saleDataBase.Status = status;
              
            if(saleDataBase.Status != status)
            return BadRequest("Valor invalido, verife o Status da compra ");

            _context.Sales.Update(saleDataBase);
            _context.SaveChanges();
            return Ok(saleDataBase);
      }
    }
}