using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalloWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HalloWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaskenAPIController : ControllerBase
    {
        DataManager db = new DataManager();

        // GET: api/MaskenAPI
        [HttpGet]
        public IEnumerable<Maske> Get()
        {
            return db.GetAll();
        }

        // GET: api/MaskenAPI/5
        [HttpGet("{id}", Name = "Get")]
        public Maske Get(int id)
        {
            return db.GetById(id);
        }

        // POST: api/MaskenAPI
        [HttpPost]
        public void Post([FromBody] Maske maske)
        {
            db.Add(maske);
        }

        // PUT: api/MaskenAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Maske maske)
        {
            db.Update(maske);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var old = db.GetById(id);
            if (old != null)
                db.Delete(old);
        }
    }
}
