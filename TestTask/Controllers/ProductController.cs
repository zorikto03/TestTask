using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly TT_DB_Context _dbContext;

        public ProductController(TT_DB_Context context)
        {
            _dbContext = context;
        }
        
            
            
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var list = _dbContext.Products;
            return list;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var prod = _dbContext.Products.FirstOrDefault(x=>x.Id == id);

            return prod;
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            var old = _dbContext.Products.FirstOrDefault(x => x.Name == value.Name);
            if (old != null)
            {
                return BadRequest($"product {value.Name} already exists");
            }

            _dbContext.Products.Add(value);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            var old = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (old != null)
            {
                old.Price = value.Price;
                old.Name = value.Name;
                _dbContext.Update(old);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest($"product id: {id} does not exists");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prod = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (prod != null)
            {
                _dbContext.Products.Remove(prod);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest($"product id: {id} does not exists");
        }
    }
}
