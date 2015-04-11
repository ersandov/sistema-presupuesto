using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaLiquidaciones
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAceptar3_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar3_Click(object sender, EventArgs e)
        {
            MpeProcesoEliminar.Hide();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MpeProcesoEliminar.Show();
        }
    }
}