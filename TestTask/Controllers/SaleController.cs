using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using TestTask.Models;

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

        [HttpGet]
        public IActionResult Sale([FromBody] Sale sale)
        {
            var buyer = User.Identities.FirstOrDefault().Claims.ToList();
            var name = buyer.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            if (name != null)
            {
                var buyerid = _context.Buyers.FirstOrDefault(x => x.Name == name)?.Id;
                sale.BuyerId = buyerid;

            }

            return Ok();
        }
    }
}
