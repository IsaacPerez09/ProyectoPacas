using ConectarData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPACAS.Controllers
{
    public class DetallesFacturaController : ApiController
    {
        private BDPACASEntities dbContext = new BDPACASEntities();

        //Visualiza todos los registros (api/detalles_factura)
        [HttpGet]

        public IEnumerable<detalle_factura> Get()
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.detalle_factura.ToList();
            }
        }


        ////

        //Visualiza solo un registro (api/detalle factura/1)
        [HttpGet]

        public detalle_factura Get(int id)
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.detalle_factura.FirstOrDefault(e => e.iddetalle_factura == id);

            }
        }



        //Graba nuevos registros en la base de datos de detalle factura
        [HttpPost]

        public IHttpActionResult AgregarDetalleFac([FromBody]detalle_factura df)
        {
            if (ModelState.IsValid)
            {
                dbContext.detalle_factura.Add(df);
                dbContext.SaveChanges();
                return Ok(df);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public IHttpActionResult ActualizarDetalleFac(int id, [FromBody]detalle_factura ct)
        {
            if (ModelState.IsValid)
            {
                var DetalleFacaExiste = dbContext.detalle_factura.Count(c => c.iddetalle_factura == id) > 0;

                if (DetalleFacaExiste)
                {
                    dbContext.Entry(ct).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]

        public IHttpActionResult EliminarDetalleFac(int id)
        {
            var ct = dbContext.detalle_factura.Find(id);

            if (ct != null)
            {
                dbContext.detalle_factura.Remove(ct);
                dbContext.SaveChanges();

                return Ok(ct);
            }
            else
            {
                return NotFound();
            }
        }





        /////




    }
}
