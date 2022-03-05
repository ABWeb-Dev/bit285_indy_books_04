using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using IndyBooks.Models;
using System.Linq;
using System;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IndyBooks.Models.IndyBooksDataContext _db;
        public WriterController(Models.IndyBooksDataContext db)
        {
            _db = db;
        }
        // GET: api/<WriterController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Writers);
        }

        // GET api/<WriterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            long dbCount = _db.Writers.Count();

            if(id < 0 || id > dbCount)
            {
                return NotFound();  
            }

            return Ok(_db.Writers.Find(id));
        }
        // POST api/<WriterController>
        [HttpPost]
        public IActionResult Post([FromBody] Writer writer)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            _db.Writers.Add(writer);
            _db.SaveChanges(); 

            return Accepted();
        }

        // PUT api/<WriterController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Writer writer)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            long dbCount = _db.Writers.Count();

            if (id < 0 || id > dbCount)
            {
                return NotFound();
            }

            writer.Id = id;

            _db.Update(writer);
            _db.SaveChanges();

            return Accepted();
        }

        // DELETE api/<WriterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            long dbCount = _db.Writers.Count();

            if (id < 0 || id > dbCount)
            {
                return NotFound();
            }

            _db.Remove(new Writer()
            {
                Id = id
            });

            _db.SaveChanges();

            return Accepted();
        }
    }
}
