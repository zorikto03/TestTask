using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using TestTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        readonly TT_DB_Context _context;
        public SaleController(TT_DB_Context context)
        {
            _context = context;
        }

        
        [HttpPost]
        public IActionResult Sale([FromBody] Sale sale)
        {
            string message = string.Empty;
            var buyerId = GetBuyerId();

            sale.BuyerId = buyerId;
            sale.Date = System.DateTime.Now;

            var salePoint = _context.SalesPoints.Include(x=>x.ProvidedProducts).FirstOrDefault(x=>x.Id == sale.SalesPointId);
            if (salePoint != null)
            {
                if (CheckSale(sale.SalesData, salePoint, out message))
                {
                    sale.SalesData.ToList().ForEach(i =>
                    {
                        var provided = salePoint.ProvidedProducts?.FirstOrDefault(x => i.ProductId == x.ProductId);
                        if (provided != null)
                        {
                            provided.Count -= i.ProductQuantity;
                        }
                        _context.SalesData.Add(i);

                    });
                    _context.Sales.Add(sale);
                    _context.SaveChanges();
                    return Ok(message);
                }
                return BadRequest(message);
            }

            return BadRequest($"SalePointId: {sale.SalesPointId} not found");
        }

        int? GetBuyerId()
        {
            int? buyerId = null;
            var buyer = User.Identities.FirstOrDefault().Claims.ToList();
            var name = buyer.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (name != null)
            {
                buyerId = _context.Buyers.FirstOrDefault(x => x.Name == name)?.Id;
            }
            return buyerId;
        }

        bool CheckSale(List<SaleData> list, SalesPoint salePoint, out string message)
        {
            message = string.Empty;
            foreach(var i in list.ToList())
            {
                var provided = salePoint.ProvidedProducts?.FirstOrDefault(x => i.ProductId == x.ProductId);
                if (provided == null || provided.Count < i.ProductQuantity)
                {
                    message = $"ProductId: {i.ProductId} in stock less than in the check";
                    return false;
                }
            }
            return true;
        }
    }
}
