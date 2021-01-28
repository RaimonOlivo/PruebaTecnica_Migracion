using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Model;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private APIContext db;

        public PersonasController(APIContext context)
        {
            db = context;
        }

        // CRUD
        // Create Personas
        [HttpPost]
        public ActionResult createPersona(Personas persona)
        {
            // TODO: Filter out id value to avoid DB problems
            db.Personas.Add(persona);
            db.SaveChanges();
            return Ok();
        }

        // Request Personas
        [HttpGet]
        public IEnumerable<Personas> getPersonas()
        {
            var personas = db.Personas.ToArray();
            return personas;
        }

        // Update Personas
        [HttpPut]
        public ActionResult updatePersona(int id, Personas persona)
        {
            var oldPersona = db.Personas.Find(id);
            if(oldPersona != null)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
            }
            return NotFound();
        }

        // Delete Personas
        [HttpDelete]
        public ActionResult deletePersona(int id)
        {
            var persona = db.Personas.Find(id);
            if(persona != null)
            {
                db.Personas.Remove(persona);
                db.SaveChanges();
                return Ok();
            }
            
            return NotFound();
        }

    }
}
