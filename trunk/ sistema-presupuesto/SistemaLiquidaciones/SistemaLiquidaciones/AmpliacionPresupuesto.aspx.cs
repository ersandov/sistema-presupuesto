using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using LiquidacionServices.BE;
using System.Text;
//using SistemaLiquidaciones.ProxyGasto;

namespace SistemaLiquidaciones
{
    public partial class AmpliacionPresupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var m = (Principal)this.Master;
                m.FindControl("li_RegistroGastos").Visible = false;
            }

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

            gvPresupuesto.DataSource = ListarGastosExcedidos();
            gvPresupuesto.DataBind();


        }
        protected void gvPresupuesto_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ampliar")
            {
                string x = e.CommandArgument.ToString();


                //string posdata = "{\"Codigo\":\"1\",\"Nombre\":\"Gerencia Marketi\"}";
                //byte[] data = Encoding.UTF8.GetBytes(posdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:50534/GastoExcedidoSrv.svc/GastosExcedidosAmp/" + x);
                req.Method = "PUT";
                //req.ContentLength = data.Length;
                //req.ContentType = "application/json";
                //var reqStream = req.GetRequestStream();
                //reqStream.Write(data, 0, data.Length);
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string gastoExcJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string PresupuestoAct = js.Deserialize<string>(gastoExcJson);


                gvPresupuesto.DataSource = ListarGastosExcedidos();
                gvPresupuesto.DataBind();
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "popup", "alert('Se actualizó el presupuesto satisfactoriamnete.');", true);
            }
        }

        private List<PresupuestoBE> ListarGastosExcedidos()
        {
            ProxyUsuario.UsuarioBE Usuario = (ProxyUsuario.UsuarioBE)Session["USUARIO"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:50534/GastoExcedidoSrv.svc/GastosExcedidos/" + Usuario.CENTROGESTORID + "/" + ddlAño.SelectedValue + "/" + ddlMes.SelectedValue);
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string gastoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PresupuestoBE> gastolista = js.Deserialize<List<PresupuestoBE>>(gastoJson);
            return gastolista;
        }
    }
}