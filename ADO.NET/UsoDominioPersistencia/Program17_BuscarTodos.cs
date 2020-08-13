using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Persistencia;
using ADO.NET.Dominio;

namespace ADO.NET
{
    class Program17_BuscarTodos
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
