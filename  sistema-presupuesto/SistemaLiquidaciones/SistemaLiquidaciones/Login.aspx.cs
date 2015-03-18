using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaLiquidaciones;

namespace SistemaLiquidaciones
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ProxyUsuario.UsuarioSrvClient proxy = new ProxyUsuario.UsuarioSrvClient();
            SistemaLiquidaciones.ProxyUsuario.UsuarioBE usuario = proxy.ObtenerUsuario(txtUsuario.Text.Trim(), txtPassword.Text.Trim());

            if (usuario == null)
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "popup", "alert('Su user y/o password son incorrectos');", true);
            }
            else
            {
                Session["USUARIO"] = usuario;
                if (usuario.PERFIL == "G")
                {
                    Response.Redirect("ConsultarPresupuestoDisponible.aspx");
                }
                else if (usuario.PERFIL == "U")
                {
                    Response.Redirect("RegistroGasto.aspx");
                }

            }

        }
    }
}