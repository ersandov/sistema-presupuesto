using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LiquidacionServices.BE;

namespace LiquidacionServices.DA
{
    public class PartidaDA
    {
        string cad = "Data Source=.;Initial Catalog=BD_LIQUIDACION;Integrated Security=SSPI;";

        public List<PartidaBE> ListarPartidas(int CentroGestorId)
        {
            List<PartidaBE> lista = new List<PartidaBE>();
            PartidaBE oPartidaBE;
            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_LISTARPARTIDAPORCENTROGES", cn);
                cmd.Parameters.Add("@CENTROGESTORID", SqlDbType.Int).Value = CentroGestorId;

                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oPartidaBE = new PartidaBE();
                    oPartidaBE.PARTIDAID = (int)dr["PARTIDAID"];
                    oPartidaBE.PARTIDA = (string)dr["PARTIDA"];
                    lista.Add(oPartidaBE);

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