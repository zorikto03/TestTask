using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidedProductController : ControllerBase
    {
        readonly TT_DB_Context _dbContext;

        public ProvidedProductController(TT_DB_Context dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ProvidedProductsController>
        [HttpGet]
        public IEnumerable<ProvidedProduct> Get()
        {
            var list = _dbContext.ProvidedProducts;
            return list;
        }

        // GET api/<ProvidedProductsController>/5
        [HttpGet("{id}")]
        public ProvidedProduct Get(int id)
        {
            var provid = _dbContext.ProvidedProducts.FirstOrDefault(x=>x.Id == id);
            return provid;
        }
        
        // GET api/<ProvidedProductsController>/GetByPoint/5
        [HttpGet("GetByPoint/{id}")]
        public List<ProvidedProduct> GetByPoint(int id)
        {
            var provid = _dbContext.ProvidedProducts.Where(x => x.SalesPointId == id).ToList();
            return provid;
        }

        // POST api/<ProvidedProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProvidedProduct value)
        {
            var old = _dbContext.ProvidedProducts.FirstOrDefault(x=>x.ProductId == value.ProductId && x.SalesPointId == value.SalesPointId);
            if (old != null)
            {
                return BadRequest("");
            }
            _dbContext.ProvidedProducts.Add(value);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<ProvidedProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProvidedProduct value)
        {
            var old = _dbContext.ProvidedProducts.FirstOrDefault(x => x.Id == id);
            if (old != null)
            {
                old.ProductId = value.ProductId;
                old.SalesPointId = value.SalesPointId;
                old.Count = value.Count;

                _dbContext.ProvidedProducts.Update(old);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest($"ProvidedProduct Id: {id} not found");
        }

        // DELETE api/<ProvidedProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prov = _dbContext.ProvidedProducts.FirstOrDefault(x => x.Id == id);
            if (prov != null)
            {
                _dbContext.ProvidedProducts.Remove(prov);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest($"ProvidedProduct Id: {id} not found");
        }
    }
}
