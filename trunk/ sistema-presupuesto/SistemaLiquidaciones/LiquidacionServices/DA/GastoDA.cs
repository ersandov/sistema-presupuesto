using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using LiquidacionServices.BE;
using System.Data;

namespace LiquidacionServices.DA
{
    public class GastoDA
    {
        string cad = "Data Source=.;Initial Catalog=BD_LIQUIDACION;Integrated Security=SSPI;";

        public int RegistrarGasto(PresupuestoBE oPresupuestoBE)
        {
            int EsRegistrado = 0;
            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_REGISTRARDETPRESUPUESTO", cn);
                cmd.Parameters.Add("@CENTROGESTORID", SqlDbType.Int).Value = oPresupuestoBE.CENTROGESTORID;
                cmd.Parameters.Add("@PARTIDAID", SqlDbType.Int).Value = oPresupuestoBE.PARTIDAID;
                cmd.Parameters.Add("@ANHO", SqlDbType.Int).Value = oPresupuestoBE.ANHO;
                cmd.Parameters.Add("@MES", SqlDbType.Char, 2).Value = oPresupuestoBE.MES;
                cmd.Parameters.Add("@MONTO", SqlDbType.Decimal).Value = oPresupuestoBE.MONTO;
                cmd.Parameters.Add("@ESREGISTRADO", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                EsRegistrado = (int)cmd.Parameters["@ESREGISTRADO"].Value;
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return EsRegistrado;

        }


        public List<PresupuestoBE> ListarGastos(PresupuestoBE oPresupuestoBE)
        {
            List<PresupuestoBE> lista = new List<PresupuestoBE>();
            PresupuestoBE oPresupuestoBE2;
            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_LISTARDETPRESUPUESTO", cn);
                cmd.Parameters.Add("@CENTROGESTORID", SqlDbType.Int).Value = oPresupuestoBE.CENTROGESTORID;
                cmd.Parameters.Add("@PARTIDAID", SqlDbType.Int).Value = oPresupuestoBE.PARTIDAID;
                cmd.Parameters.Add("@ANHO", SqlDbType.Int).Value = oPresupuestoBE.ANHO;
                cmd.Parameters.Add("@MES", SqlDbType.Char, 2).Value = oPresupuestoBE.MES;

                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oPresupuestoBE2 = new PresupuestoBE();
                    oPresupuestoBE2.DETPRESUPUESTO = (int)dr["DETPRESUPUESTO"];
                    oPresupuestoBE2.ANHO = (int)dr["ANHO"];
                    oPresupuestoBE2.MES = (string)dr["MES"];
                    oPresupuestoBE2.CENTROGESTOR = (string)dr["CENTROGESTOR"];
                    oPresupuestoBE2.PARTIDA = (string)dr["PARTIDA"];
                    oPresupuestoBE2.MONTO = double.Parse(dr["MONTO"].ToString());
                    lista.Add(oPresupuestoBE2);

                }
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;

        }
        public int EliminarGasto(int detaPresupuestoId)
        {
            int EsRegistrado = 0;
            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_ELIMINARDETPRESUPUESTO", cn);
                cmd.Parameters.Add("@DETPRESUPUESTO", SqlDbType.Int).Value = detaPresupuestoId;
                cmd.Parameters.Add("@EsEliminado", SqlDbType.Int).Direction = ParameterDirection.Output;


                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                EsRegistrado = (int)cmd.Parameters["@EsEliminado"].Value;

                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return EsRegistrado;

        }

        public List<PresupuestoBE> ListarGastosExcedidos(string centroGestorId, string anho, string mes)
        {
            List<PresupuestoBE> lista = new List<PresupuestoBE>();
            PresupuestoBE oPresupuestoBE;
            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_LISTARPRESUPUESTOEXCEDIDOS", cn);
                cmd.Parameters.Add("@CENTROGESTORID", SqlDbType.Int).Value = centroGestorId;
                cmd.Parameters.Add("@ANHO", SqlDbType.Int).Value = anho;
                cmd.Parameters.Add("@MES", SqlDbType.Char, 2).Value = mes;

                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oPresupuestoBE = new PresupuestoBE();

                    oPresupuestoBE.DETPRESUPUESTO = (int)dr["DETPRESUPUESTO"];
                    oPresupuestoBE.PARTIDA = (string)dr["PARTIDA"];
                    oPresupuestoBE.MONTO = double.Parse(dr["MONTO"].ToString());
                    oPresupuestoBE.MONTOEXCEDIDO = double.Parse(dr["MONTOEXCEDIDO"].ToString());
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

        public int AmpliarPresupuesto(int detapresupuestoid)
        {
            int EsActualizado;

            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_AMPLIACIONGASTO", cn);
                cmd.Parameters.Add("@DETPRESUPUESTO", SqlDbType.Int).Value = detapresupuestoid;
                cmd.Parameters.Add("@EsActualizado", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                EsActualizado = (int)cmd.Parameters["@EsActualizado"].Value;
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return EsActualizado;

        }

        public int ConsultarGastoExcedido(PresupuestoBE oPresupuestoBE)
        {
            int Excedido;

            try
            {

                SqlConnection cn = new SqlConnection(cad);
                SqlCommand cmd = new SqlCommand("SP_CONSULTARGASTOEXCEDIDO", cn);
                cmd.Parameters.Add("@CENTROGESTORID", SqlDbType.Int).Value = oPresupuestoBE.CENTROGESTORID;
                cmd.Parameters.Add("@PARTIDAID", SqlDbType.Int).Value = oPresupuestoBE.PARTIDAID;
                cmd.Parameters.Add("@ANHO", SqlDbType.Int).Value = oPresupuestoBE.ANHO;
                cmd.Parameters.Add("@MES", SqlDbType.Char, 2).Value = oPresupuestoBE.MES;
                cmd.Parameters.Add("@MONTO", SqlDbType.Decimal).Value = oPresupuestoBE.MONTO;
                cmd.Parameters.Add("@EXCEDIDO", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                Excedido = (int)cmd.Parameters["@EXCEDIDO"].Value;
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return Excedido;

        }

    }
}