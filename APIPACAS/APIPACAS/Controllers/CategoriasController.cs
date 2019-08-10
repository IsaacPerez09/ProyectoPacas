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
    public class CategoriasController : ApiController
    {
        private BDPACASEntities dbContext = new BDPACASEntities();

        //Visualiza todos los registros (api/categorias)
        [HttpGet]

        public IEnumerable<categoria> Get()
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.categorias.ToList();
            }
        }



        ////

        //Visualiza solo un registro (api/categoria/1)
        [HttpGet]

        public categoria Get(int id)
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.categorias.FirstOrDefault(e => e.idcategoria == id);

            }
        }



        //Graba nuevos registros en la base de datos de categorias
        [HttpPost]

        public IHttpActionResult AgregarCategoria([FromBody]categoria ct)
        {
            if (ModelState.IsValid)
            {
                dbContext.categorias.Add(ct);
                dbContext.SaveChanges();
                return Ok(ct);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public IHttpActionResult ActualizarCategoria(int id, [FromBody]categoria ct)
        {
            if (ModelState.IsValid)
            {
                var CategoriaExiste = dbContext.categorias.Count(c => c.idcategoria == id) > 0;

                if (CategoriaExiste)
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

        public IHttpActionResult EliminarCategoria(int id)
        {
            var ct = dbContext.categorias.Find(id);

            if (ct != null)
            {
                dbContext.categorias.Remove(ct);
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
