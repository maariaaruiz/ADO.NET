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
    class Program16_BuscarUno_Factura
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            Factura factura = repositorio.BuscarUno(1);
            Console.WriteLine(factura.CONCEPTO);
           
          
            Console.ReadLine();
        }
    }
}
