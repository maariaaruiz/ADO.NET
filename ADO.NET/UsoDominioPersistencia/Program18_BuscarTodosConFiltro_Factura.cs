using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Persistencia.Filtros;
using Semicrol.Cursos.Dominio;

namespace ADO.NET
{
    class Program18_BuscarTodosConFiltro_Factura
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            FiltroFactura2 filtro = new FiltroFactura2().AddConcepto("televsior").AddNumero(1);

           
            List<Factura> facturas = repositorio.BuscarTodos(filtro);

            foreach (Factura f in facturas)
            {
                Console.WriteLine(f.CONCEPTO);
            }
         
           
          
            Console.ReadLine();
        }
    }
}
