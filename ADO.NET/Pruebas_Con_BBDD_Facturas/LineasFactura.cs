using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class LineasFactura
    {
        public int Numero { get; set; }
        public int Facturas_num { get; set; }
        //public FacturaActiveRecord Facturas_num { get; set; }
        public string Productos_id { get; set; }
        public int Unidades { get; set; }

        public LineasFactura()
        {

        }

        public LineasFactura(int numero, int facturas_num, string productos_id, int unidades)
        {
            Numero = numero;
            Facturas_num = facturas_num;
            Productos_id = productos_id;
            Unidades = unidades;
        }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings =
              ConfigurationManager.ConnectionStrings["miconexion"];
            string cadena = settings.ConnectionString;
            return cadena;
        }

        public void Insertar()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "insert into LineasFactura VALUES (@Numero,@Facturas_numero,@Productos_id,@Unidades)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Facturas_numero", Facturas_num);
                comando.Parameters.AddWithValue("@Productos_id", Productos_id);
                comando.Parameters.AddWithValue("@Unidades", Unidades);

                comando.ExecuteNonQuery();
            };

        }
        public void Borrar(int num)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "DELETE FROM LineasFactura WHERE NUMERO=" + num + "";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            };

        }

        }
    }


