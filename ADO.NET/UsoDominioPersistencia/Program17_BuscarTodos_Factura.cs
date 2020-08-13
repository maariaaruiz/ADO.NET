using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Dominio;

namespace ADO.NET
{
    class Program17_BuscarTodos_Factura
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            List<Factura> facturas = repositorio.BuscarTodos();

            foreach (Factura f in facturas)
            {
                Console.WriteLine(f.CONCEPTO);
            }
         
           
          
            Console.ReadLine();
        }
    }
}
