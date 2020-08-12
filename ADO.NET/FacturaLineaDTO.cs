using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FacturaLineaDTO
    {
        public int NumeroFactura { get; set; }
        public string ConceptoFactura { get; set; }
        public string Producto_id { get; set; }
        public int Unidades { get; set; }

        public FacturaLineaDTO(int numeroFactura, string conceptoFactura, string producto_id, int unidades)
        {
            NumeroFactura = numeroFactura;
            ConceptoFactura = conceptoFactura;
            Producto_id = producto_id;
            Unidades = unidades;
        }
        private static string CadenaConexion()
        {
            ConnectionStringSettings settings =
              ConfigurationManager.ConnectionStrings["miconexion"];
            string cadena = settings.ConnectionString;
            return cadena;
        }

        public static List<FacturaLineaDTO> BuscarFacturasLineas()
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                List<FacturaLineaDTO> facturaslineas = new List<FacturaLineaDTO>();
                conexion.Open();
                string sql = "select Facturas.NUMERO,Facturas.CONCEPTO,LineasFactura.PRODUCTOS_ID,LineasFactura.UNIDADES FROM  Facturas,LineasFactura WHERE Facturas.NUMERO=LineasFactura.FACTURAS_NUMERO";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    facturaslineas.Add(new FacturaLineaDTO(Convert.ToInt32(lector["NUMERO"]), lector["CONCEPTO"].ToString(),lector["PRODUCTOS_ID"].ToString(), Convert.ToInt32(lector["UNIDADES"])));
                }
                return facturaslineas;
            }

        }

    }
}
