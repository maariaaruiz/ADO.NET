using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.PersistenciaADO;

namespace ADO.NET
{
    class Program14_Insertar_Factura
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            repositorio.Insertar(new Factura(20, "Tablet"));
            Console.ReadLine();
        }
    }
}
