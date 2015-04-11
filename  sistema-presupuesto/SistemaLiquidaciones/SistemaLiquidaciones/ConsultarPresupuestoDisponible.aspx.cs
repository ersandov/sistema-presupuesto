using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaLiquidaciones
{
    public partial class ConsultarPresupuestoDisponible : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OcultarSubMenu();
                CargarGrilla();
                if (!Page.IsPostBack)
                {
                    var m = (Principal)this.Master;
                    m.FindControl("li_RegistroGastos").Visible = false;
                }
            }

        }
        private void OcultarSubMenu()
        {
            var m = (Principal)this.Master;
            ProxyUsuario.UsuarioBE Usuario = (ProxyUsuario.UsuarioBE)Session["USUARIO"];
            if (Usuario != null)
            {
                if (Usuario.PERFIL == "G")
                {
                    m.FindControl("li_RegistroGastos").Visible = false;
                }
            }


        }
        private void CargarGrilla()
        {

            ProxyPresupuesto.PresupuestoSrvClient proxy = new ProxyPresupuesto.PresupuestoSrvClient();
            ProxyUsuario.UsuarioBE Usuario = (ProxyUsuario.UsuarioBE)Session["USUARIO"];
            if (proxy != null && Usuario != null)
            {
                gvPresupuesto.DataSource = proxy.ConsultarPresupuestoDispo(Usuario.CENTROGESTORID, int.Parse(ddlAño.SelectedValue), ddlMes.SelectedValue);
                gvPresupuesto.DataBind();
                if (gvPresupuesto.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "popup", "alert('No hay presupuestos disponibles para este año y mes.');", true);
                }
            }

        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}