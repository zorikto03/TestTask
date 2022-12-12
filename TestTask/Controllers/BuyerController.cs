using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        readonly TT_DB_Context _context;
        readonly ILogger<BuyerController> _logger;

        public BuyerController(TT_DB_Context context, ILogger<BuyerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/<BuyerController>
        [HttpGet]
        public IEnumerable<Buyer> Get()
        {
            var buyers = _context.Buyers;

            return buyers;
        }

        // GET api/<BuyerController>/5
        [HttpGet("{id}")]
        public Buyer Get(int id)
        {
            var buyer = _context.Buyers.FirstOrDefault(x => x.Id == id);
 
            return buyer;
        }

        // POST api/<BuyerController>
        [HttpPost]
        public void Post([FromBody] Buyer value)
        {
            var old = _context.Buyers.FirstOrDefault(x=>x.Id == value.Id);
            if (old != null)
            {
                old.Name = value.Name;
                _context.Update(old);
            }
            else
            {
                _context.Add(value);
            }
            _context.SaveChanges();
        }

        // PUT api/<BuyerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Buyer value)
        {
            var old = _context.Buyers.FirstOrDefault(x => x.Id == id);
            if (old != null)
            {
                old.Name = value.Name;
                _context.Update(old);
            }
            else
            {
                _context.Add(value);
            }
            _context.SaveChanges();
        }

        // DELETE api/<BuyerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var buyer = _context.Buyers.FirstOrDefault(x => x.Id == id);
            if (buyer != null)
            {
                _context.Buyers.Remove(buyer);
                _context.SaveChanges();
            }
        }
    }
}
