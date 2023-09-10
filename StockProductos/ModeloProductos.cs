using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockProductos
{
    public class ModeloProductos
    {
        public string detalleProducto { get; set; }
        public string fechaOperacion { get; set; }   
        public string tipoOperacion { get; set; }   
        public int cantidad { get; set; }   
    }
}