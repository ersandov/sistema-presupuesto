<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="MantenimientoUsuario.aspx.cs" Inherits="SistemaLiquidaciones.MantenimientoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/StyleMenu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%;">
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
                                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;">
                                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;">
                                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPerfil" runat="server" Text="Perfil"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="caja_texto">
                                    <asp:ListItem Value="U">Usuario</asp:ListItem>
                                    <asp:ListItem Value="G">Gerente</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnAgregar" runat="server" Text="Registrar" CssClass="boton"
                                    OnClick="btnAgregar_Click" Width="150px" />
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
                    </table>
                </div>
                <div style="width: 70%; float: left;">
                    <asp:GridView ID="gvGastos" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" >
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="" HeaderText="Nombre" />
                            <asp:BoundField DataField="" HeaderText="Apellidos" />
                            <asp:BoundField DataField="" HeaderText="Usuario" />
                            <asp:BoundField DataField="" HeaderText="Perfil" />
                            <asp:BoundField DataField="" HeaderText="Centro Gestor" />
                             <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/Imagenes/editar.png"
                                        Width="20px" Height="20px" CommandName="Eliminar"  />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/Imagenes/delete.png"
                                        Width="20px" Height="20px" CommandName="Eliminar" />
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
</asp:Content>
