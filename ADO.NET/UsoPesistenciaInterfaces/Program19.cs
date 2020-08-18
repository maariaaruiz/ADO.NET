using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Persistencia.Filtros;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.PersistenciaADO;

namespace ADO.NET
{
    class Program19
    {
        static void Main(string[] args)
        {
            IFacturaRepository repositorio = new FacturaRepository();

            List<Factura> lista = repositorio.BuscarTodosConLineas();

            foreach (Factura f in lista)
            {
                Console.WriteLine(f.CONCEPTO);
                foreach (LineaFactura lf in  f.lineas)
                {
                    Console.WriteLine(lf.Unidades);
                }
            }
         
           
          
            Console.ReadLine();
        }
    }
}
