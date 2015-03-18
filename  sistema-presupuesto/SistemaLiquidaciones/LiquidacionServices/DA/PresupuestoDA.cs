using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LiquidacionServices.BE;

namespace LiquidacionServices.DA
{
    public class PresupuestoDA
    {
       string cad = "Data Source=.;Initial Catalog=BD_LIQUIDACION;Integrated Security=SSPI;";

       public List<PresupuestoBE> ConsultarPresupuestoDispo(int CentroGestorId,int anho,string mes)
       {
           List<PresupuestoBE> lista = new List<PresupuestoBE>();
           PresupuestoBE oPresupuestoBE;
           try
           {

               SqlConnection cn = new SqlConnection(cad);
               SqlCommand cmd = new SqlCommand("SP_CONSULTARPRESUPUESTODISPON", cn);
               cmd.Parameters.Add("@CENTROGESTORID", SqlDbType.Int).Value = CentroGestorId;
                cmd.Parameters.Add("@ANHO",SqlDbType.Int).Value=anho;
                cmd.Parameters.Add("@MES",SqlDbType.Char,2).Value=mes;

               SqlDataReader dr;
               cmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               dr = cmd.ExecuteReader();
               while (dr.Read())
               {
                   oPresupuestoBE = new PresupuestoBE();
                   oPresupuestoBE.PARTIDA = (string)dr["PARTIDA"];
                   oPresupuestoBE.MONTO = double.Parse(dr["MONTO"].ToString());
                   oPresupuestoBE.MONTODISPONIBLE = double.Parse(dr["MONTODISPONIBLE"].ToString());
                   lista.Add(oPresupuestoBE);

               }
               cn.Close();
           }
           catch (Exception)
           {

               throw;
           }
           return lista;

       }

    }
}