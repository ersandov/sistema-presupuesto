using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaLiquidaciones
{
    public partial class RegistroGasto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var m = (Principal)this.Master;
                m.FindControl("li_Disponibilidad").Visible = false;
                m.FindControl("li_Ampliacion").Visible = false;
                CargarComboCentro();
            }
        }
        private void CargarComboCentro()
        {
            ProxyCentroGestor.CentroGestorSrvClient proxyCentro = new ProxyCentroGestor.CentroGestorSrvClient();

            ddlCentroGestor.DataSource = proxyCentro.ListarCentroGestor();
            ddlCentroGestor.DataValueField = "CENTROGESTORID";
            ddlCentroGestor.DataTextField = "CENTROGESTOR";
            ddlCentroGestor.DataBind();
            CargarComboPartida();
        }

        private void CargarComboPartida()
        {
            ProxyPartida.PartidaSrvClient proxyPartida = new ProxyPartida.PartidaSrvClient();
            ddlPartida.DataSource = proxyPartida.ListarPartidas(int.Parse(ddlCentroGestor.SelectedValue));
            ddlPartida.DataValueField = "PARTIDAID";
            ddlPartida.DataTextField = "PARTIDA";
            ddlPartida.DataBind();
        }
        protected void ddlCentroGestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboPartida();
        }
    }
}