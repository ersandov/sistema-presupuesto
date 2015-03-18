<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroGasto.aspx.cs" Inherits="SistemaLiquidaciones.RegistroGasto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="Styles/Style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/StyleMenu.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width:100%;">
    <div style="width:200px;height:800px; float:left;"></div>
    <div style="width:70%;float:left;">
         <table >
         <tr>
            <td colspan="3">
                <asp:Label ID="lblTitulo" runat="server" Text="Registro de Gastos por Partida Presupuestal" Font-Size="12pt" Font-Bold="true"></asp:Label>
                <hr />
            </td>
         </tr>
        <tr>
            <td style="width:130px;">
                <asp:Label ID="lblAño" runat="server" Text="Año"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAño" runat="server" CssClass="caja_texto">
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
             <td>
                <asp:Label ID="lblMes" runat="server" Text="Mes"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMes" runat="server" CssClass="caja_texto">
                    <asp:ListItem Value="01">Enero</asp:ListItem>
                    <asp:ListItem Value="02">Febreo</asp:ListItem>
                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                    <asp:ListItem Value="04">Abril</asp:ListItem>
                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                    <asp:ListItem Value="06">Junio</asp:ListItem>
                    <asp:ListItem Value="07">Julio</asp:ListItem>
                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                    <asp:ListItem Value="09">Setiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCentroGestor" runat="server" Text="Centro Gestor"></asp:Label>
            </td>
            <td style="width:200px;">
                <asp:DropDownList ID="ddlCentroGestor" runat="server" CssClass="caja_texto" 
                    AutoPostBack="True" OnSelectedIndexChanged="ddlCentroGestor_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPartida" runat="server" Text="Partida"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPartida" runat="server" CssClass="caja_texto">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMonto" runat="server" Text="Monto Consumo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConsumo" runat="server" CssClass="caja_texto" Width="100px"></asp:TextBox>
                
            </td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Gasto" CssClass="boton"  Width="150px"/>
            </td>
        </tr>
    </table>
    </div>
    <div style="width:70%;float:left;">
        <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
            AutoGenerateColumns="False">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="p1" HeaderText="Año" />
                <asp:BoundField DataField="p2" HeaderText="Mes" />
                <asp:BoundField DataField="p3" HeaderText="Gerencia" />
                <asp:BoundField DataField="p4" HeaderText="Partida" />
                <asp:BoundField DataField="p5" HeaderText="Monto" />
                <asp:TemplateField HeaderText="Editar">
                     <ItemTemplate>
                   <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/Imagenes/editar.png" Width="20px" Height="20px"/>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                <ItemTemplate>
                   <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/Imagenes/delete.png" Width="20px" Height="20px"/>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                
            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>
  </div> 
</asp:Content>
