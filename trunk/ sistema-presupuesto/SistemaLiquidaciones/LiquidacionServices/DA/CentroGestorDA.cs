using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LiquidacionServices.BE;

namespace LiquidacionServices.DA
{
    public class CentroGestorDA
    {
        string cad = "Data Source=.;Initial Catalog=BD_LIQUIDACION;Integrated Security=SSPI;";

        public List<CentroGestorBE> ListarCentroGestor()
        {
            List<CentroGestorBE> lista = new List<CentroGestorBE>();
            CentroGestorBE oCentroGestorBE;
            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_LISTARCENTROGESTOR", cn);

                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oCentroGestorBE = new CentroGestorBE();
                    oCentroGestorBE.CENTROGESTORID = (int)dr["CENTROGESTORID"];
                    oCentroGestorBE.CENTROGESTOR = (string)dr["CENTROGESTOR"];
                    lista.Add(oCentroGestorBE);

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