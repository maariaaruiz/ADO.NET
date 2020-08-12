using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADO.NET
{
    class FacturaActiveRecord
    {
        public FacturaActiveRecord(int nUMERO, string cONCEPTO)
        {
            NUMERO = nUMERO;
            CONCEPTO = cONCEPTO;
        }

        public FacturaActiveRecord()
        {
        }

        public int NUMERO { get; set; }
        public string CONCEPTO { get; set; }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings =
              ConfigurationManager.ConnectionStrings["miconexion"];
            string cadena = settings.ConnectionString;
            return cadena;
        }

        public void Insertar()
        {
            //para hacer mas sencilla la conexion a la bbdd y no copiar toda la ruta de conexion
            //se cerrara todo lo que este abierto con la clausula using
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "insert into Facturas VALUES (@Numero,@Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", NUMERO);
                comando.Parameters.AddWithValue("@Concepto", CONCEPTO);
                comando.ExecuteNonQuery();
            };

        }
        /*CON PARAMETROS
        public void Borrar(int NUM)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "DELETE FROM Facturas WHERE NUMERO=" + NUM + "";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            };
        }*/
        //SIN PARAMETROS
        public void Borrar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "DELETE FROM Facturas WHERE NUMERO=@NUMERO";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@NUMERO", NUMERO);
                comando.ExecuteNonQuery();
            };

        }

        public static List<FacturaActiveRecord> BuscarTodos()
        {
            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector=comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(new FacturaActiveRecord(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString()));
                }
            };
            return lista;
        }

        public void Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "UPDATE Facturas SET CONCEPTO=@Numero WHERE NUMERO=@Concepto";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", NUMERO);
                comando.Parameters.AddWithValue("@Concepto", CONCEPTO);
                comando.ExecuteNonQuery();
            };
          
        }
        //revisar este metodo, le falta alguna cosa pero funciona
        public static FacturaActiveRecord BuscarUno(int num)
        {
            FacturaActiveRecord factura = null;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas WHERE NUMERO=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", num);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    factura = new FacturaActiveRecord(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString());
                }
            };
            return factura;
        }

        public static List<FacturaActiveRecord> BuscarPorConcepto(string concepto)
        {
            List<FacturaActiveRecord> facturas = new List<FacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas WHERE CONCEPTO=@Concepto";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Concepto", concepto);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    facturas.Add(new FacturaActiveRecord(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString()));
                }
                return facturas;
            };
        }

        public List<FacturaActiveRecord> BuscarTodos(FiltroFactura filtro)
        {
            List<FacturaActiveRecord> facturas = new List<FacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas";
                if (filtro.Numero != 0)
                {
                    sql += " WHERE NUMERO=@Numero";
                    if (filtro.Concepto != null)
                    {
                        sql += " AND CONCEPTO=@Concepto";
                    }
                }else
                {
                    if (filtro.Concepto != null)
                    {
                        sql += " WHERE CONCEPTO=@Concepto";
                    }
                }
              

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", NUMERO);
                comando.Parameters.AddWithValue("@Concepto", CONCEPTO);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    facturas.Add(new FacturaActiveRecord(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString()));
                }
                return facturas;
            };

        }




    }
}
