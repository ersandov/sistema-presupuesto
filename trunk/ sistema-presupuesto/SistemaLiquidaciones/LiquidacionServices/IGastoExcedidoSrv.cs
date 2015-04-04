using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using LiquidacionServices.BE;

namespace LiquidacionServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGastoExecidoSrv" in both code and config file together.
    [ServiceContract]
    public interface IGastoExcedidoSrv
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GastosExcedidos/{centroGestorId}/{anho}/{mes}", ResponseFormat = WebMessageFormat.Json)]
        List<PresupuestoBE> ListarGastosExcedidos(string centroGestorId, string anho, string mes);
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "GastosExcedidosAmp/{detapresupuestoid}", ResponseFormat = WebMessageFormat.Json)]
        string AmpliarPresupuesto(string detapresupuestoid);
    }
}
