using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program10
    {
        static void Main(string[] args)
        {
            FiltroFactura f1 = new FiltroFactura();
            List<FacturaActiveRecord> lista = FacturaActiveRecord.BuscarTodos(f1);
            foreach(FacturaActiveRecord f in lista)
            {
                Console.WriteLine(f.NUMERO + " " + f.CONCEPTO);
            }
           
           
            Console.ReadLine();
        }
    }
}
