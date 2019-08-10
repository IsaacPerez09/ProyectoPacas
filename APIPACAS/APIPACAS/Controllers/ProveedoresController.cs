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
    public class ProveedoresController : ApiController
    {
        private BDPACASEntities dbContext = new BDPACASEntities();


        //Visualiza todos los registros (api/proveedores)
        [HttpGet]

        public IEnumerable<proveedor> Get()
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.proveedors.ToList();
            }
        }


        ////

        //Visualiza solo un registro (api/proveedor/1)
        [HttpGet]

        public proveedor Get(int id)
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.proveedors.FirstOrDefault(e => e.idproveedor == id);


            }
        }



        //Graba nuevos registros en la base de datos de proveedor
        [HttpPost]

        public IHttpActionResult AgregarProveedor([FromBody]proveedor pv)
        {
            if (ModelState.IsValid)
            {
                dbContext.proveedors.Add(pv);
                dbContext.SaveChanges();
                return Ok(pv);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public IHttpActionResult ActualizarProveedor(int id, [FromBody]proveedor pv)
        {
            if (ModelState.IsValid)
            {
                var ProveedorExiste = dbContext.proveedors.Count(c => c.idproveedor == id) > 0;

                if (ProveedorExiste)
                {
                    dbContext.Entry(pv).State = EntityState.Modified;
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

        public IHttpActionResult EliminarProveedor(int id)
        {
            var pv = dbContext.proveedors.Find(id);

            if (pv != null)
            {
                dbContext.proveedors.Remove(pv);
                dbContext.SaveChanges();

                return Ok(pv);
            }
            else
            {
                return NotFound();
            }
        }





        /////
    }
}
