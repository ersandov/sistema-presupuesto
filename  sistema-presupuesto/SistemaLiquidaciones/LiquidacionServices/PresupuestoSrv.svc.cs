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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PresupuestoSrv" en el código, en svc y en el archivo de configuración a la vez.
    public class PresupuestoSrv : IPresupuestoSrv
    {
        PresupuestoDA oPresupuestoDA = new PresupuestoDA();
        public List<PresupuestoBE> ConsultarPresupuestoDispo(int CentroGestorId, int anho, string mes)
        {
            return oPresupuestoDA.ConsultarPresupuestoDispo(CentroGestorId, anho, mes);
        }

    }
}
