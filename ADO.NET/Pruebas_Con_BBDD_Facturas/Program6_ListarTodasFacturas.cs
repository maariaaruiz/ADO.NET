using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program6_ListarTodasFacturas
    {
        static void Main(string[] args)
        {
            List<FacturaActiveRecord> lista = FacturaActiveRecord.BuscarTodos();
            foreach (FacturaActiveRecord f in lista)
            {
                Console.WriteLine(f.CONCEPTO);
            }
         
        Console.ReadLine();
        }
    }
}
