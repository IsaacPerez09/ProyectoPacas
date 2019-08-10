using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONSUMIRPACAS.Models
{
    public class Productos
    {
        public int idproducto { get; set; }
        public int idcategoria { get; set; }
        public int idproveedor { get; set; }
        public string nombreProducto { get; set; }
        public int stock { get; set; }
        public string fecha_ingreso { get; set; }
        public double precioVenta { get; set; }
        public double precioCosto { get; set; }
        public string descripcionProducto { get; set; }
    }

}