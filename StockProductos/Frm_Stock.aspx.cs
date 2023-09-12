using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            lblInformacion.ForeColor = Color.Green;
            lblInformacion.Text = "El Producto se Registro Correctamente!";
            Limpiar();


        }
        private void Limpiar()
        {
            txtDetaleProducto.Text = string.Empty;
            dtFechaOperacion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            lblInformacion.Text += string.Empty;    
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtDetaleProducto.Text.Trim()))
            {
                lblInformacion.ForeColor = Color.Red;
                lblInformacion.Text = "El campo Detalle Producto es Obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(dtFechaOperacion.Text.Trim()))
            {
                lblInformacion.ForeColor = Color.Red;
                lblInformacion.Text = "El campo Fecha de Operación es Obligatorio";
                return false;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()) || Convert.ToInt32(txtCantidad.Text) <=0)
            {
                lblInformacion.ForeColor = Color.Red;
                lblInformacion.Text = "El campo cantidad es Obligatorio o debe ser mayor a 0";
                return false;
            }
         
            lblInformacion.Text = "";
            return true;    
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(Validar())
            GuardarProducto();
        }

        protected void dtFechaOperacion_TextChanged(object sender, EventArgs e)
        {
            string fechaTexto = dtFechaOperacion.Text;

            if (DateTime.TryParseExact(fechaTexto, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
           
                dtFechaOperacion.Text = fecha.ToString("dd/MM/yyyy");
            }
            else
            {
                dtFechaOperacion.Text = fecha.ToString();
            }
        }

        private HtmlTable CrearTablaHtml()
        {

            var tablaHtml = new HtmlTable();

          
            var filaEncabezado = new HtmlTableRow();

       
            var encabezadoDetProducto = new HtmlTableCell();
            encabezadoDetProducto.InnerText = "Detalle de Producto";
            encabezadoDetProducto.Attributes["style"] = "width: 300px;"; 
            filaEncabezado.Cells.Add(encabezadoDetProducto);

    
            var encabezadoFecha = new HtmlTableCell();
            encabezadoFecha.InnerText = "Fecha de Operación";
            encabezadoFecha.Attributes["style"] = "width: 200px;"; 
            filaEncabezado.Cells.Add(encabezadoFecha);

            var encabezadoTipoOperacion = new HtmlTableCell();
            encabezadoTipoOperacion.InnerText = "Tipo de Operación";
            encabezadoTipoOperacion.Attributes["style"] = "width: 150px;"; 
            filaEncabezado.Cells.Add(encabezadoTipoOperacion);

      
            var encabezadoCantidad = new HtmlTableCell();
            encabezadoCantidad.InnerText = "Cantidad";
            encabezadoCantidad.Attributes["style"] = "width: 100px;"; 
            filaEncabezado.Cells.Add(encabezadoCantidad);

            tablaHtml.Rows.Add(filaEncabezado);

            return tablaHtml;
        }

        private void LeerArchivo()
        {
            string filePath = $"{Server.MapPath(".")}/data.txt";
            lblInformacion.Text = string.Empty;
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string json = sr.ReadToEnd();
                List<ModeloProductos> productos = JsonSerializer.Deserialize<List<ModeloProductos>>(json);


                var tablaProductos = CrearTablaHtml();

            

                foreach (var item in productos)
                {
                    var fila = new HtmlTableRow();
                    var DetProdu = new HtmlTableCell();
                    DetProdu.InnerText = item.detalleProducto; 
                    fila.Cells.Add(DetProdu);

                    var Fecha = new HtmlTableCell();
                    Fecha.InnerText = item.fechaOperacion; 
                    fila.Cells.Add(Fecha);

                    var tipoOperacion = new HtmlTableCell();
                    tipoOperacion.InnerText = item.tipoOperacion;
                    fila.Cells.Add(tipoOperacion);


                    var Cantidad = new HtmlTableCell();
                    Cantidad.InnerText = item.cantidad.ToString();
                    fila.Cells.Add(Cantidad);

                    tablaProductos.Rows.Add(fila);

                }
                sr.Close();

                // Convierte la tabla HTML a una cadena de texto
                string tablaHtmlStr = RenderControlAsString(tablaProductos);

                // Asigna la cadena de texto a la etiqueta <label>
                lblInformacion.ForeColor = Color.Indigo; 
                lblInformacion.Text = tablaHtmlStr;

            }
        }

        protected void btnMovimientos_Click(object sender, EventArgs e)
        {
            LeerArchivo();
        }
        private string RenderControlAsString(Control control)
        {
            using (StringWriter writer = new StringWriter())
            {
                control.RenderControl(new HtmlTextWriter(writer));
                return writer.ToString();
            }
        }
    }
}