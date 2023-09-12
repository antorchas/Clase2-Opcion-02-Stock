<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Stock.aspx.cs" Inherits="StockProductos.Frm_Stock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Stock de Productos</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
    
<body>
    <form id="form1" runat="server">
    <div class="container">
         <h1 class="titulo">Registro de Productos</h1>
        <div class="row mt-2" >
            <div class="col-sm-3">
                <asp:Label ID="Label1" runat="server" Text="Detalle Producto:"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:TextBox ID="txtDetaleProducto" ValidationGroup="Registro" runat="server"></asp:TextBox>
            </div>
           
        </div>
        
        <div class="row mt-2">
            <div class="col-sm-3">
                <asp:Label ID="Label2" runat="server" Text="Fecha de Operación:"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:TextBox type="Date" ID="dtFechaOperacion" ValidationGroup="Registro" runat="server" OnTextChanged="dtFechaOperacion_TextChanged"></asp:TextBox>
            </div>
        </div>

        <div class="row mt-2">
            <div class="col-sm-3">
                <asp:Label ID="Label3" runat="server" Text="Tipo de Operación:"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:Label ID="Label4" runat="server" Text="Compra"></asp:Label>
                <asp:RadioButton ID="rbCompra" runat="server" GroupName="TipoMovimiento" />
                <asp:Label ID="Label5" runat="server" Text="Venta"></asp:Label>
                <asp:RadioButton ID="rbVenta" runat="server" Checked="true" GroupName="TipoMovimiento" />
            </div>
        </div>

        <div class="row mt-2">
            <div class="col-sm-3">
                <asp:Label ID="Label6" runat="server" Text="Cantidad:"></asp:Label>
            </div>
            <div class="col-sm-9">
                <asp:TextBox type="number" ValidationGroup="Registro" ID="txtCantidad" runat="server"></asp:TextBox>
            </div>
        </div>
           <div class="row mt-2">
                  <div class="col-sm-3">

   </div>
       <div class="col-sm-2">
           <asp:Button ID="btnRegistrar" type="submit" runat="server" ValidationGroup="Registro" Text="Registrar" OnClick="btnRegistrar_Click" />
       </div>
               
               <div class="col-sm-2">
       <asp:Button ID="btnMovimientos" runat="server" CausesValidation="false" Text="Ver Movimientos" OnClick="btnMovimientos_Click"  />
   </div>

   </div>
                  <div class="row mt-2"> 
                                       <div class="col-sm-2">

  </div>
  <div class="col-sm-8">
      <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
      </div>
          </div>
    </div>
</form>

</body>
</html>






<style>
    .titulo {
    text-align: center; 
    font-size: 28px; 
    color: #333; 
    margin-bottom: 20px; 
   
}
  
</style>

