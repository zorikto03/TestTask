using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPointController : ControllerBase
    {
        readonly TT_DB_Context _dbContext;
        public SalesPointController(TT_DB_Context context)
        {
            _dbContext = context;
        }

        // GET: api/<SalesPointController>
        [HttpGet]
        public IEnumerable<SalesPoint> Get()
        {
            var list = _dbContext.SalesPoints.Include(x => x.ProvidedProducts);
            return list;
        }

        // GET api/<SalesPointController>/5
        [HttpGet("{id}")]
        public SalesPoint Get(int id)
        {
            var point = _dbContext.SalesPoints.Include(x => x.ProvidedProducts).FirstOrDefault(x=>x.Id == id);

            return point ;
        }

        // POST api/<SalesPointController>
        [HttpPost]
        public IActionResult Post([FromBody] SalesPoint value)
        {
            var old = _dbContext.SalesPoints.FirstOrDefault(x=>x.Name == value.Name);
            if (old != null)
            {
                return BadRequest($"SalesPoint {value.Name} already exists");
            }

            _dbContext.SalesPoints.Add(value);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<SalesPointController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SalesPoint value)
        {
            var old = _dbContext.SalesPoints.FirstOrDefault(x => x.Id == id);
            if (old == null)
            {
                return BadRequest($"SalesPoint Id: {id} does not exists");
            }

            old.Name = value.Name;
            _dbContext.SalesPoints.Update(old);
            _dbContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<SalesPointController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var old = _dbContext.SalesPoints.FirstOrDefault(x => x.Id == id);
            if(old != null)
            {
                _dbContext.Remove(old);
                _dbContext.SaveChanges();
                return Ok();
            } 
            return BadRequest($"SalesPoint id: {id} does not exists");
        }
    }
}
