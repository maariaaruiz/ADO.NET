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


namespace Semicrol.Cursos.PersistenciaADO
{
    public class FacturaRepository: IFacturaRepository
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

        //Se pueden devolver 3 cosas:
        //lista de objetos- siempre lo mejor (devolver una Nota,Factura,..., en vez de un tipo de dato(string, int , double,..))
        //grafo - a partir de inner join
        //DTO ventajas(hechoss a medida) desventajas(mas clases, mas mantenimiento)
        public List<Factura> BuscarTodosConLineas()
        {

            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select Facturas.NUMERO as facturaNumero," +
                             "Facturas.CONCEPTO," +
                             " LineasFactura.NUMERO as lineaNumero," +
                             "UNIDADES,PRODUCTOS_ID" +
                             " from Facturas inner join LineasFactura " +
                             "on Facturas.NUMERO = LineasFactura.FACTURAS_NUMERO";

                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                List<Factura> listaFacturas = new List<Factura>();

                while (lector.Read())
                {
                    Factura f = new Factura(Convert.ToInt32(lector["facturaNumero"]));
                    if (!listaFacturas.Contains(f))
                    {

                        f.CONCEPTO = lector["concepto"].ToString();
                        listaFacturas.Add(f);
                    }
                    else
                    {

                        f = listaFacturas
                            .Find((facturita) => facturita.NUMERO == Convert.ToInt32(lector["facturaNumero"]));
                    }

                    LineaFactura linea = new LineaFactura(Convert.ToInt32(lector["lineaNumero"]),f);
                    linea.Unidades = Convert.ToInt32(lector["unidades"]);
                    linea.Productos_id = lector["productos_id"].ToString();
                    f.AddLinea(linea);

                }

                return listaFacturas;
            }

        }

     

        Factura IFacturaRepository.BuscarUno(int num)
        {
            throw new NotImplementedException();
        }

    }
}
