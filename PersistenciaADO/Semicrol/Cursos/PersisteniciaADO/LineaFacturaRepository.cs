using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semicrol.Cursos.Persistencia;

namespace Semicrol.Cursos.PersistenciaADO
{
   public class LineaFacturaRepository:ILineaFacturaRepository
    {
        private static string CadenaConexion()
        {
            ConnectionStringSettings settings =
              ConfigurationManager.ConnectionStrings["miconexion"];
            string cadena = settings.ConnectionString;
            return cadena;
        }

        public void Insertar(LineaFactura linea)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "insert into LineasFactura VALUES (@Numero,@Facturas_numero,@Productos_id,@Unidades)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", linea.Numero);
                comando.Parameters.AddWithValue("@Facturas_numero", linea.factura.NUMERO);
                comando.Parameters.AddWithValue("@Productos_id", linea.Productos_id);
                comando.Parameters.AddWithValue("@Unidades", linea.Unidades);

                comando.ExecuteNonQuery();
            };
        }

        public void Borrar(LineaFactura linea)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "DELETE FROM LineasFactura WHERE NUMERO=@Numero AND FACTURAS_NUMERO=@NUMERO_FACTURA";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@NUMERO", linea.Numero);
                comando.Parameters.AddWithValue("@NUMERO_FACTURA", linea.factura.NUMERO);
                comando.ExecuteNonQuery();
            };
        }

        public void Actualizar(LineaFactura linea)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "UPDATE LineasFactura SET UNIDADES=@Unidades WHERE NUMERO=@Numero AND FACTURAS_NUMERO=@NUMERO_FACTURA";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", linea.Numero);
                comando.Parameters.AddWithValue("@NUMERO_FACTURA", linea.factura.NUMERO);
                comando.Parameters.AddWithValue("@Unidades", linea.Unidades);
                comando.ExecuteNonQuery();
            };

        }

        public List<LineaFactura> BuscarTodasLineas()
        {
            List<LineaFactura> lista = new List<LineaFactura>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    //añadir constructor
                   // lista.Add(new LineaFactura(Convert.ToInt32(lector["NUMERO"]), Convert.ToInt32(lector["FACTURAS_NUMERO"]), Convert.ToString(lector["PRODUCTOS_ID"]), Convert.ToInt32(lector["UNIDADES"])));
                }
            };
            return lista;
        }

   
        public LineaFactura BuscarUnaLinea(int num)
        {
            LineaFactura factura = null;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from LineasFactura WHERE NUMERO=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", num);
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                   // factura = new LineaFactura(Convert.ToInt32(lector["NUMERO"]), Convert.ToInt32(lector["FACTURAS_NUMERO"]), Convert.ToString(lector["PRODUCTOS_ID"]), Convert.ToInt32(lector["UNIDADES"]));
                    return factura;
                }
                else
                {
                    return null;
                }
            };
        }



    }

    }

