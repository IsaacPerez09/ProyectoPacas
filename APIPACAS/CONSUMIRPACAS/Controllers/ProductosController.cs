using CONSUMIRPACAS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CONSUMIRPACAS.Controllers
{
    public class ProductosController : Controller
    {
        //URL donde se ubica nuestra Api
        string Baseurl = "http://romariosolorzano-001-site1.itempurl.com/";

        public async Task<ActionResult> Index()
        {
            List<Productos> EmpInfo = new List<Productos>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //llama todos los productos usando el HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/productos/");
                if (Res.IsSuccessStatusCode)
                {
                    //Si Res=True entra y asigna los datos
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializar el api y almacena los datos 
                    EmpInfo = JsonConvert.DeserializeObject<List<Productos>>(EmpResponse);
                }
            }

            //Muestra la lista de todas las categorias 
            return View(EmpInfo);
        }
    }
}