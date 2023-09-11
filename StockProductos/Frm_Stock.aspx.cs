using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockProductos
{
    public partial class Frm_Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        private string DevolverTipoOperacion()
        {
            if (rbCompra.Checked) return "Compra";
            else if (rbVenta.Checked) return "Venta";
            return "";
        }

        private void GuardarProducto()
        {

            string filePath = $"{Server.MapPath(".")}/data.txt";

            List<ModeloProductos> productos;

            if (File.Exists(filePath))
            {
               
                string json = File.ReadAllText(filePath);
                productos = JsonSerializer.Deserialize<List<ModeloProductos>>(json);
            }
            else
            {
                
                productos = new List<ModeloProductos>();
            }
            ModeloProductos nuevoProducto = new ModeloProductos
            {
                detalleProducto = txtDetaleProducto.Text.Trim(),
                fechaOperacion = dtFechaOperacion.Text.ToString().Trim(),
                tipoOperacion = DevolverTipoOperacion(),
                cantidad = Convert.ToInt32(txtCantidad.Text.Trim()),

            };
            productos.Add(nuevoProducto);

            StreamWriter sw = new StreamWriter(filePath);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string nuevoJson = JsonSerializer.Serialize(productos, options);


            sw.WriteLine(nuevoJson);
            sw.Close();


        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }
    }
}