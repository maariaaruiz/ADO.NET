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
                string sql = "insert into Facturas VALUES (" + NUMERO + ",'" + CONCEPTO + "')";
                SqlCommand comando = new SqlCommand(sql, conexion);
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
                string sql = "DELETE FROM Facturas WHERE NUMERO=" + NUMERO ;
                SqlCommand comando = new SqlCommand(sql, conexion);
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

    }
}
