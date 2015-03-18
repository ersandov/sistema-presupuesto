using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiquidacionServices.BE;

namespace LiquidacionServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPartidaSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPartidaSrv
    {
        [OperationContract]
        List<PartidaBE> ListarPartidas(int CentroGestorId);
    }
}
