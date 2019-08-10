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
    public class FacturasController : ApiController
    {
        private BDPACASEntities dbContext = new BDPACASEntities();

        //Visualiza todos los registros (api/facturas)
        [HttpGet]

        public IEnumerable<factura> Get()
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.facturas.ToList();
            }
        }

        ////

        //Visualiza solo un registro (api/FacturasController/1)
        [HttpGet]

        public factura Get(int id)
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.facturas.FirstOrDefault(e => e.idfactura == id);

            }
        }



        //Graba nuevos registros en la base de datos de factura
        [HttpPost]

        public IHttpActionResult AgregarFactura([FromBody]factura ft)
        {
            if (ModelState.IsValid)
            {
                dbContext.facturas.Add(ft);
                dbContext.SaveChanges();
                return Ok(ft);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public IHttpActionResult ActualizarFactura(int id, [FromBody]factura ft)
        {
            if (ModelState.IsValid)
            {
                var FacturaExiste = dbContext.facturas.Count(c => c.idfactura == id) > 0;

                if (FacturaExiste)
                {
                    dbContext.Entry(ft).State = EntityState.Modified;
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

        public IHttpActionResult Eliminarfactura(int id)
        {
            var ft = dbContext.facturas.Find(id);

            if (ft != null)
            {
                dbContext.facturas.Remove(ft);
                dbContext.SaveChanges();

                return Ok(ft);
            }
            else
            {
                return NotFound();
            }
        }





        /////


    }
}
