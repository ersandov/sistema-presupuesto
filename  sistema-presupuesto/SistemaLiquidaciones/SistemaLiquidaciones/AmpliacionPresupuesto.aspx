<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AmpliacionPresupuesto.aspx.cs" Inherits="SistemaLiquidaciones.AmpliacionPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/StyleMenu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <div style="width: 100%;">
        <div style="width: 200px; height: 800px; float: left;">
        </div>
        <div style="width: 70%; float: left;">
            <table>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblTitulo" runat="server" Text="Ampliación de Presupuesto"
                            Font-Size="12pt" Font-Bold="true"></asp:Label>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px;">
                        <asp:Label ID="lblAño" runat="server" Text="Año"></asp:Label>
                    </td>
                    <td style="width: 130px;">
                        <asp:DropDownList ID="ddlAño" runat="server" CssClass="caja_texto">
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="boton" 
                            Width="100px" onclick="btnConsultar_Click"/>
                      
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
                            <asp:ListItem Value="7">Julio</asp:ListItem>
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
            </table>
        </div>
        <div style="width: 70%; float: left;">
            <asp:GridView ID="gvPresupuesto" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" OnRowCommand="gvPresupuesto_RowCommand">
                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                <Columns>
                    <asp:BoundField DataField="PARTIDA" HeaderText="Partida" />
                    <asp:BoundField DataField="MONTO" HeaderText="Monto" />
                    <asp:BoundField DataField="MONTOEXCEDIDO" HeaderText="Monto Excedido" /> 
                    <asp:TemplateField HeaderText="Ampliar">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgAmpliar" runat="server" ImageUrl="~/imagenes/ampliacion.png" Width="20px" Height="20px" OnClientClick="return confirm('Desea ampliar el presupuesto?')" CommandName="Ampliar" CommandArgument='<%# Eval("DETPRESUPUESTO") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pgr"></PagerStyle>
            </asp:GridView>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
