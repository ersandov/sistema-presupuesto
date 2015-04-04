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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGastoSrv" in both code and config file together.
    [ServiceContract]
    public interface IGastoSrv
    {
        [OperationContract]
        int RegistrarGasto(BE.PresupuestoBE oPresupuestoBE);
        [OperationContract]
        List<BE.PresupuestoBE> ListarGastos(BE.PresupuestoBE oPresupuestoBE);
        [OperationContract]
        int EliminarGasto(int detaPresupuestoId);
        [OperationContract]
        int ConsultarGastoExcedido(BE.PresupuestoBE oPresupuestoBE);
    }
}
