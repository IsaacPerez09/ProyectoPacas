using ConectarData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace APIPACAS.Controllers
{
    public class ProductosController : ApiController
    {
        private BDPACASEntities dbContext = new BDPACASEntities();

        //Visualiza todos los registros (api/productos)
        [HttpGet]

        public IEnumerable<producto> Get()
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.productoes.ToList();


            } 
        }


        //Visualiza solo un registro (api/productos/1)
        [HttpGet]

        public producto Get(int id)
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.productoes.FirstOrDefault( e => e.idproducto == id);
                
            }
        }



        //Graba nuevos registros en la base de datos de productos
        [HttpPost]

        public IHttpActionResult AgregarProducto([FromBody]producto pro)
        {
         if (ModelState.IsValid)
            {
                dbContext.productoes.Add(pro);
                dbContext.SaveChanges();
                return Ok(pro);
            }
         else
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public IHttpActionResult ActualizarProducto(int id, [FromBody]producto pro)
        {
            if (ModelState.IsValid)
            {
                var ProductoExiste = dbContext.productoes.Count(c => c.idproducto == id) > 0;

                if (ProductoExiste)
                {
                    dbContext.Entry(pro).State = EntityState.Modified;
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

        public IHttpActionResult EliminarProducto(int id)
        {
            var pro = dbContext.productoes.Find(id);

            if ( pro != null)
            {
                dbContext.productoes.Remove(pro);
                dbContext.SaveChanges();

                return Ok(pro);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
