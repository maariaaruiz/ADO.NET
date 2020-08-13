using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Persistencia;
using ADO.NET.Dominio;
using ADO.NET.Persistencia.Filtros;

namespace ADO.NET
{
    class Program18_BuscarTodosConFiltro
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            FiltroFactura2 filtro = new FiltroFactura2();
            filtro.AddConcepto ( "CompraA");
            List<Factura> facturas = repositorio.BuscarTodos(filtro);

            foreach (Factura f in facturas)
            {
                Console.WriteLine(f.CONCEPTO);
            }
         
           
          
            Console.ReadLine();
        }
    }
}
