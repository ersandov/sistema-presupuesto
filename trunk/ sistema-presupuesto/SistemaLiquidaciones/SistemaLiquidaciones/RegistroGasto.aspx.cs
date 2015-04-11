using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaLiquidaciones.ProxyGasto;


namespace SistemaLiquidaciones
{
    public partial class RegistroGasto : System.Web.UI.Page
    {
        ProxyGasto.GastoSrvClient proxyGasto = new ProxyGasto.GastoSrvClient();
        ProxyCentroGestor.CentroGestorSrvClient proxyCentro = new ProxyCentroGestor.CentroGestorSrvClient();
        ProxyPartida.PartidaSrvClient proxyPartida = new ProxyPartida.PartidaSrvClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var m = (Principal)this.Master;
                m.FindControl("li_Disponibilidad").Visible = false;
                m.FindControl("li_Ampliacion").Visible = false;
                CargarComboCentro();
                ListarGastos();
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

            ddlPartida.DataSource = proxyPartida.ListarPartidas(int.Parse(ddlCentroGestor.SelectedValue));
            ddlPartida.DataValueField = "PARTIDAID";
            ddlPartida.DataTextField = "PARTIDA";
            ddlPartida.DataBind();
        }

        protected void ddlCentroGestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboPartida();
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            ListarGastos();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            PresupuestoBE oPresupuestoBE = new PresupuestoBE();

            try
            {
                if (txtConsumo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "popup", "alert('Debe ingresar un monto.');", true);
                    return;
                }
                oPresupuestoBE.CENTROGESTORID = int.Parse(ddlCentroGestor.SelectedValue);
                oPresupuestoBE.PARTIDAID = int.Parse(ddlPartida.SelectedValue);
                oPresupuestoBE.ANHO = int.Parse(ddlAño.SelectedValue);
                oPresupuestoBE.MES = ddlMes.SelectedValue;
                oPresupuestoBE.MONTO = double.Parse(txtConsumo.Text);
                int excedido = proxyGasto.ConsultarGastoExcedido(oPresupuestoBE);
                if (excedido == 2)
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "popup", "alert('No hay presupuesto para los filtros ingresados.');", true);
                }
                else if (excedido == 1)
                {
                    MpeAmpliarPresupuesto.Show();
                }
                else
                {
                    proxyGasto.RegistrarGasto(oPresupuestoBE);
                }

                ListarGastos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ListarGastos()
        {
            try
            {
                PresupuestoBE oPresupuestoBE = new PresupuestoBE();
                oPresupuestoBE.CENTROGESTORID = int.Parse(ddlCentroGestor.SelectedValue);
                oPresupuestoBE.PARTIDAID = int.Parse(ddlPartida.SelectedValue);
                oPresupuestoBE.ANHO = int.Parse(ddlAño.SelectedValue);
                oPresupuestoBE.MES = ddlMes.SelectedValue;
                gvGastos.DataSource = proxyGasto.ListarGastos(oPresupuestoBE);
                gvGastos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void gvGastos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                try
                {
                    proxyGasto.EliminarGasto(int.Parse(e.CommandArgument.ToString()));
                    ListarGastos();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        protected void btnAceptar3_Click(object sender, EventArgs e)
        {
            PresupuestoBE oPresupuestoBE = new PresupuestoBE();
            try
            {
                oPresupuestoBE.CENTROGESTORID = int.Parse(ddlCentroGestor.SelectedValue);
                oPresupuestoBE.PARTIDAID = int.Parse(ddlPartida.SelectedValue);
                oPresupuestoBE.ANHO = int.Parse(ddlAño.SelectedValue);
                oPresupuestoBE.MES = ddlMes.SelectedValue;
                oPresupuestoBE.MONTO = double.Parse(txtConsumo.Text);
                proxyGasto.RegistrarGasto(oPresupuestoBE);
                ListarGastos();
                MpeAmpliarPresupuesto.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancelar3_Click(object sender, EventArgs e)
        {
            MpeAmpliarPresupuesto.Hide();
        }

    }
}