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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioSrv" en el código, en svc y en el archivo de configuración a la vez.
    public class UsuarioSrv : IUsuarioSrv
    {
        UsuarioDA oUsuarioDA = new UsuarioDA();
        public UsuarioBE ObtenerUsuario(string usuario, string contrasena)
        {
            return oUsuarioDA.ObtenerUsuario(usuario, contrasena);
        }

    }
}
