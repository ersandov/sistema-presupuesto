using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidacionServices.DA;
using LiquidacionServices.BE;

namespace LiquidacionServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GastoSrv" in code, svc and config file together.
    public class GastoSrv : IGastoSrv
    {
        GastoDA oGastoDA = new GastoDA();
        public int RegistrarGasto(PresupuestoBE oPresupuestoBE)
        {
            return oGastoDA.RegistrarGasto(oPresupuestoBE);
        }

        public List<PresupuestoBE> ListarGastos(PresupuestoBE oPresupuestoBE)
        {
            return oGastoDA.ListarGastos(oPresupuestoBE);
        }

        public int EliminarGasto(int detaPresupuestoId)
        {
            return oGastoDA.EliminarGasto(detaPresupuestoId);
        }

        public int ConsultarGastoExcedido(PresupuestoBE oPresupuestoBE)
        {
            return oGastoDA.ConsultarGastoExcedido(oPresupuestoBE);
        }
    }
}
