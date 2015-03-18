using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LiquidacionServices.BE;

namespace LiquidacionServices.DA
{
    public class UsuarioDA
    {
        string cad = "Data Source=.;Initial Catalog=BD_LIQUIDACION;Integrated Security=SSPI;";

        public UsuarioBE ObtenerUsuario(string usuario, string contrasena)
        {
            UsuarioBE oUsuarioBE=null;
            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_OBTENERUSUARIO", cn);
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 20).Value = usuario;
                cmd.Parameters.Add("@CONTRASENA", SqlDbType.VarChar, 20).Value = contrasena;

                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oUsuarioBE = new UsuarioBE();
                    oUsuarioBE.USUARIOID = (int)dr["USUARIOID"];
                    oUsuarioBE.NOMBRES = (string)dr["NOMBRES"];
                    oUsuarioBE.APELLIDOS = (string)dr["APELLIDOS"];
                    oUsuarioBE.USUARIO = (string)dr["USUARIO"];
                    oUsuarioBE.CONTRASENA = (string)dr["CONTRASENA"];
                    oUsuarioBE.PERFIL = (string)dr["PERFIL"];
                    oUsuarioBE.CENTROGESTORID = (int)dr["CENTROGESTORID"];
                }
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return oUsuarioBE;

        }
    }
}