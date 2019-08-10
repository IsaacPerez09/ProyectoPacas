using CONSUMIRPACAS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CONSUMIRPACAS.Models;

namespace CONSUMIRPACAS.Controllers
{
    public class CategoriasController : Controller
    {
        //URL donde se ubica nuestra Api
        string Baseurl = "http://romariosolorzano-001-site1.itempurl.com/";

        public async Task  <ActionResult> Index()
        {
            List<Categorias> EmpInfo = new List<Categorias>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //llama todas las categorias usando el HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/categorias/");
                if (Res.IsSuccessStatusCode)
                {
                    //Si Res=True entra y asigna los datos
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializar el api y almacena los datos 
                    EmpInfo = JsonConvert.DeserializeObject<List<Categorias>>(EmpResponse);   
                }
            }

                //Muestra la lista de todas las categorias 
                return View(EmpInfo);
        }
    }
}