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


    }
}
