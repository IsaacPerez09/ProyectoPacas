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
    public class Tipo_DocumentoController : ApiController
    {
        private BDPACASEntities dbContext = new BDPACASEntities();

        //Visualiza todos los registros (api/tipodocumento)
        [HttpGet]

        public IEnumerable<tipo_de_documento> Get()
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.tipo_de_documento.ToList();
            }
        }

        ////

        //Visualiza solo un registro (api/tipodoc/1)
        [HttpGet]

        public tipo_de_documento Get(int id)
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.tipo_de_documento.FirstOrDefault(e => e.id_tipo_de_documento== id);

            }
        }



        //Graba nuevos registros en la base de datos de tipodoc
        [HttpPost]

        public IHttpActionResult AgregarTipo_Doc([FromBody]tipo_de_documento tpd)
        {
            if (ModelState.IsValid)
            {
                dbContext.tipo_de_documento.Add(tpd);
                dbContext.SaveChanges();
                return Ok(tpd);
               }
            else
            {
                return BadRequest();
            }
        }

        ///
        [HttpPut]

        public IHttpActionResult ActualizarTipoDoc(int id, [FromBody]tipo_de_documento tpd)
        {
            if (ModelState.IsValid)
            {
                var TipoDocExiste = dbContext.tipo_de_documento.Count(c => c.id_tipo_de_documento == id) > 0;

                if (TipoDocExiste)
                {
                    dbContext.Entry(tpd).State = EntityState.Modified;
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

        public IHttpActionResult EliminarTipoDoc(int id)
        {
            var tpd = dbContext.tipo_de_documento.Find(id);

            if (tpd != null)
            {
                dbContext.tipo_de_documento.Remove(tpd);
                dbContext.SaveChanges();

                return Ok(tpd);
            }
            else
            {
                return NotFound();
            }
        }




        ////
    }
}
