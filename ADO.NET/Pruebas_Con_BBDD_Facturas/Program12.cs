using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program12
    {
        static void Main(string[] args)
        {

            List<FacturaLineaDTO> lista = FacturaLineaDTO.BuscarFacturasLineas();
            foreach (FacturaLineaDTO l in lista)
            {
               Console.WriteLine( l.NumeroFactura+" "+l.ConceptoFactura+" "+l.Producto_id+" "+l.Unidades);
            }
       


            Console.ReadLine();
        }
    }
}
