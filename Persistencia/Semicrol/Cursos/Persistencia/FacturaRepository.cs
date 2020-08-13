using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Persistencia.Filtros;
using Semicrol.Cursos.Dominio;

namespace Semicrol.Cursos.Persistencia
{
    public class FacturaRepository:IFacturaRepository
    {

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings =
              ConfigurationManager.ConnectionStrings["miconexion"];
            string cadena = settings.ConnectionString;
            return cadena;
        }

        public void Insertar(Factura factura)
        {
           using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "insert into Facturas VALUES (@Numero,@Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero",factura.NUMERO);
                comando.Parameters.AddWithValue("@Concepto", factura.CONCEPTO);
                comando.ExecuteNonQuery();
            };
        }

        public void Borrar(Factura factura)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "DELETE FROM Facturas WHERE NUMERO=@NUMERO";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@NUMERO", factura.NUMERO);
                comando.ExecuteNonQuery();
            };
        }

        public void Actualizar(Factura factura)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "UPDATE Facturas SET CONCEPTO=@Concepto WHERE NUMERO=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.NUMERO);
                comando.Parameters.AddWithValue("@Concepto", factura.CONCEPTO);
                comando.ExecuteNonQuery();
            };

        }

       public List<Factura> BuscarTodos()
        {
            List<Factura> lista = new List<Factura>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(new Factura(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString()));
                }
            };
            return lista;
        }

       public Factura BuscarUno(int num)
        {
            Factura factura = null;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                string sql = "select * from Facturas WHERE NUMERO=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", num);
                SqlDataReader lector = comando.ExecuteReader();

               if (lector.Read())
                {
                    factura = new Factura(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString());
                    return factura;
                }
                else
                {
                    return null;
                }
            };  
        }

       public List<Factura> BuscarTodos(FiltroFactura2 filtro)
        {
            SqlCommand comando = new SqlCommand();
            List<Factura> facturas = new List<Factura>();
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
                }
                else
                {
                    if (filtro.Concepto != null)
                    {
                        sql += " WHERE CONCEPTO=@Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                    }
                }

                comando.Connection = conexion;
                comando.CommandText = sql;
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    facturas.Add(new Factura(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString()));

                }
                return facturas;
            };
        }

        List<Factura> IFacturaRepository.BuscarTodos()
        {
            throw new NotImplementedException();
        }

        List<Factura> IFacturaRepository.BuscarTodos(FiltroFactura2 filtro)
        {
            throw new NotImplementedException();
        }

        Factura IFacturaRepository.BuscarUno(int num)
        {
            throw new NotImplementedException();
        }
    }
}
