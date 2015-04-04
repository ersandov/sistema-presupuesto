using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidacionServices.BE;
using LiquidacionServices.DA;

namespace LiquidacionServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GastoExecidoSrv" in code, svc and config file together.
    public class GastoExecidoSrv : IGastoExecidoSrv
    {
        GastoDA oGastoDA = new GastoDA();
        public List<PresupuestoBE> ListarGastosExcedidos(string centroGestorId, string anho, string mes)
        {
            return oGastoDA.ListarGastosExcedidos(centroGestorId, anho, mes);
        }

        public string AmpliarPresupuesto(string detapresupuestoid)
        {
            return oGastoDA.AmpliarPresupuesto(int.Parse(detapresupuestoid)).ToString();
        }

    }
}
