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
    public class ClientesController : ApiController
    {
        private BDPACASEntities dbContext = new BDPACASEntities();

        //Visualiza todos los registros (api/clientes)
        [HttpGet]

        public IEnumerable<cliente> Get()
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.clientes.ToList();
            }
        }
        ////

        //Visualiza solo un registro (api/cliente/1)
        [HttpGet]

        public cliente Get(int id)
        {
            using (BDPACASEntities bdpacasentities = new BDPACASEntities())
            {
                return bdpacasentities.clientes.FirstOrDefault(e => e.idcliente == id);

            }
        }



        //Graba nuevos registros en la base de datos de clientes
        [HttpPost]

        public IHttpActionResult AgregarCliente([FromBody]cliente cli)
        {
            if (ModelState.IsValid)
            {
                dbContext.clientes.Add(cli);
                dbContext.SaveChanges();
                return Ok(cli);
               }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public IHttpActionResult ActualizarCliente(int id, [FromBody]cliente cli)
        {
            if (ModelState.IsValid)
            {
                var ClienteExiste = dbContext.clientes.Count(c => c.idcliente == id) > 0;

                if (ClienteExiste)
                {
                    dbContext.Entry(cli).State = EntityState.Modified;
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

        public IHttpActionResult EliminarCliente(int id)
        {
            var cli = dbContext.clientes.Find(id);

            if (cli != null)
            {
                dbContext.clientes.Remove(cli);
                dbContext.SaveChanges();

                return Ok(cli);
            }
            else
            {
                return NotFound();
            }
        }





        /////
    }
}
