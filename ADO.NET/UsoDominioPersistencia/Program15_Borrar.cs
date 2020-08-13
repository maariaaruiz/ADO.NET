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
    class Program14_Borrar
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            repositorio.Borrar(new Factura(20));
            Console.ReadLine();
        }
    }
}
