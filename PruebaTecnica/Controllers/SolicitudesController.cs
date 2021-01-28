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
    public class SolicitudesController : ControllerBase
    {
        private APIContext db;

        public SolicitudesController(APIContext context)
        {
            db = context;
        }

        // CRUD
        // Create Solicitud
        [HttpPost]
        public ActionResult createSolicitud(Solicitud solicitud)
        {
            // TODO: Filter out id value to avoid DB problems
            db.Solicitud.Add(solicitud);
            db.SaveChanges();
            return Ok();
        }

        // Request Solicitudes
        [HttpGet]
        public IEnumerable<Solicitud> getSolicitudes()
        {
            var solicitudes = db.Solicitud.ToArray();
            return solicitudes;
        }

        // Update Solicitud
        [HttpPut]
        public ActionResult updateSolicitud(int id, Solicitud solicitud)
        {
            var oldSolicitud = db.Solicitud.Find(id);
            if (oldSolicitud != null)
            {
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
            }
            return NotFound();
        }

        // Delete Solicitud
        [HttpDelete]
        public ActionResult deleteSolicitud(int id)
        {
            var solicitud = db.Solicitud.Find(id);
            if (solicitud != null)
            {
                db.Solicitud.Remove(solicitud);
                db.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        // List Solicitudes by Estado
        [HttpGet]
        [Route("byEstado")]
        public IEnumerable<Solicitud> getSolicitudesByEstado(int estadoId)
        {
            var solicitudes = db.Solicitud
                .Where(x => x.Estado.id == estadoId)
                .ToArray();
            
            if(solicitudes.Count() == 0)
            {
                NotFound();
            }

            return solicitudes;
        }
    }
}
