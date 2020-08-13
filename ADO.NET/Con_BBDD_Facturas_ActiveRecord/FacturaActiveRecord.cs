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

                if (lector.Read())
                {
                    factura = new FacturaActiveRecord(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString());
                    return factura;
                }
                else
                {
                    return null;
                }
            };
          
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

        //buscar todos con filtro
        public static List<FacturaActiveRecord> BuscarTodos(FiltroFactura filtro)
        {
            SqlCommand comando = new SqlCommand();
            List<FacturaActiveRecord> facturas = new List<FacturaActiveRecord>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas";
                if (filtro.Numero != 0)
                {
                    sql += " WHERE NUMERO=@Numero";
                    comando.Parameters.AddWithValue("@Numero", filtro.Numero);
                    if (filtro.Concepto != null)
                    {
                        sql += " AND CONCEPTO=@Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                    }
                }else
                {
                    if (filtro.Concepto != null)
                    {
                        sql += " WHERE CONCEPTO=@Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                    }
                }

                comando.Connection = conexion;
                comando.CommandText=sql;
              
              
               
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    facturas.Add(new FacturaActiveRecord(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString()));
                }
                return facturas;
            };
        }

        public  List<LineasFactura> BuscarLineasFactura()
        {
            List<LineasFactura> lineas = new List<LineasFactura>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from LineasFactura WHERE FACTURAS_NUMERO=@Facturas_numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Facturas_numero", NUMERO);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lineas.Add(new LineasFactura(
                        Convert.ToInt32(lector["NUMERO"]),
                        Convert.ToInt32(lector["FACTURAS_NUMERO"]),
                        lector["PRODUCTOS_ID"].ToString(),
                        Convert.ToInt32(lector["UNIDADES"])));
                   }

                return lineas;
            };
           
        }

        //utilizmos clase DTO
        public List<FacturaLineaDTO> BuscarFacturasLineas()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                List<FacturaLineaDTO> facturaslineas = new List<FacturaLineaDTO>();
                conexion.Open();
                string sql = "select Facturas.NUMERO,Facturas.CONCEPTO, " +
                    "LineasFactura.PRODUCTOS_ID,LineasFactura.UNIDADES FROM " +
                    "Facturas,LineasFactura WHERE Facturas.NUMERO=LineasFactura.FACTURAS_NUMERO";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    facturaslineas.Add(new FacturaLineaDTO(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString(), lector["PRODUCTOS_ID"].ToString(), Convert.ToInt32(lector["UNIDADES"])));
                }
                return facturaslineas;
            }

        }
        //devuelve las unidades totales
        public static void UnidadesTotales()
        {//puede ser static int y poner el console en el main
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                int unidades=0;
                conexion.Open();
                string sql = "SELECT SUM(UNIDADES) AS TOTAL_UNIDADES FROM LineasFactura ";
                SqlCommand comando = new SqlCommand(sql, conexion);
                unidades = Convert.ToInt32(comando.ExecuteScalar());
              
                Console.WriteLine("Hay "+ unidades + " unidades");
            };
        }


    }
}
