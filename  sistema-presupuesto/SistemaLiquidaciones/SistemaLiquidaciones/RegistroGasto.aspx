<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" 
CodeBehind="RegistroGasto.aspx.cs" Inherits="SistemaLiquidaciones.RegistroGasto" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="Styles/Style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/StyleMenu.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div style="width:100%;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="width: 200px; height: 800px; float: left;">
                </div>
                <div style="width: 70%; float: left;">
                    <table>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblTitulo" runat="server" Text="Registro de Gastos por Partida Presupuestal"
                                    Font-Size="12pt" Font-Bold="true"></asp:Label>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;">
                                <asp:Label ID="lblAño" runat="server" Text="Año"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAño" runat="server" CssClass="caja_texto">
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMes" runat="server" Text="Mes"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMes" runat="server" CssClass="caja_texto">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="0">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Setiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCentroGestor" runat="server" Text="Centro Gestor"></asp:Label>
                            </td>
                            <td style="width: 200px;">
                                <asp:DropDownList ID="ddlCentroGestor" runat="server" CssClass="caja_texto" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCentroGestor_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPartida" runat="server" Text="Partida"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPartida" runat="server" CssClass="caja_texto">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMonto" runat="server" Text="Monto Consumo"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConsumo" runat="server" CssClass="caja_texto" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="boton" OnClick="btnConsultar_Click"
                                    Width="150px" />
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Gasto" CssClass="boton" OnClick="btnAgregar_Click"
                                    Width="150px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 70%; float: left;">
                    <asp:GridView ID="gvGastos" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" OnRowCommand="gvGastos_RowCommand">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="ANHO" HeaderText="Año" />
                            <asp:BoundField DataField="MES" HeaderText="Mes" />
                            <asp:BoundField DataField="CENTROGESTOR" HeaderText="Gerencia" />
                            <asp:BoundField DataField="PARTIDA" HeaderText="Partida" />
                            <asp:BoundField DataField="MONTO" HeaderText="Monto" />
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/Imagenes/delete.png"
                                        Width="20px" Height="20px" CommandName="Eliminar" CommandArgument='<%#Eval("DETPRESUPUESTO")%>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <cc1:ModalPopupExtender runat="server" ID="MpeAmpliarPresupuesto" BackgroundCssClass="modalBackground"
        TargetControlID="Button10" PopupControlID="divProcesoEliminar" 
        Drag="true" PopupDragHandleControlID="PopupHeader">
    </cc1:ModalPopupExtender>
     <%--<cc1:modal ID="MpeAmpliarPresupuesto" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="Button10" PopupControlID="divProcesoEliminar" 
        Drag="true" PopupDragHandleControlID="PopupHeader" >
        </cc1:ModalPopupExtender>
--%>
       <%--  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<cc1:modalpopupextender ID="MpeProcesoEliminar" BackgroundCssClass="modalBackground" runat="server"
                            TargetControlID="Button10" PopupControlID="divProcesoEliminar" 
        Drag="true" PopupDragHandleControlID="PopupHeader" >
    </cc1:modalpopupextender>--%>
    <asp:Button ID="Button10" runat="server" Text="Button" Style="display: none" />
    <div  runat="server" id="divProcesoEliminar" class="PanelModal" 
        style="width:300px;height:140px; margin-right: 0px; top: 868px; left: 42px;display:none;" >
       <asp:UpdatePanel ID="UpdatePanel9" runat="server" >
        <ContentTemplate>
            <div style="width:300px;height:130px; border-style:ridge;border-color:Gray;">  
                <div style="width:301px;height:20px;background-color:#0174DF;float:left;text-align:left;color:White;">
                    <b>Mens. Ampliación</b>
                </div>
                
                <div style="width:299px;height:20px;float:left;">
                  
                </div>
                <div style="width:20px;height:40px;float:left;">
                </div>
              <%--  <div style="width:50px;height:40px;float:left;">
                    <img src="../Imagenes/informacion.gif"  width="40px" height="40px"/>
                </div>--%>
               <div style="width:260px;height:50px;float:left;padding-top:10px;text-align:left;">
                   <asp:Label ID="lblMensaje3" runat="server" Text="El gasto ha sobrepasado el límite del presupuesto ¿Desea solicitar una ampliación del presupuesto?"></asp:Label>
                </div>
                <div style="width:300px;float:left;text-align:center;">
                    <asp:Button ID="btnAceptar3" runat="server" Text="Aceptar" Font-Bold="true" CssClass = "boton" Width="89" OnClick="btnAceptar3_Click"/>
                    <asp:Button ID="btnCancelar3" runat="server" Text="Cancelar" Font-Bold="true" CssClass = "boton" Width="89" OnClick="btnCancelar3_Click"/>
                </div>
                
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
      </div>

</asp:Content>
