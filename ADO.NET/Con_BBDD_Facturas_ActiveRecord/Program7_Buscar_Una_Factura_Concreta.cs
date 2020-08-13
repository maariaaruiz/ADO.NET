using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program7_Buscar_Una_Factura_Concreta
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f1 = FacturaActiveRecord.BuscarUno(2);
          
            Console.WriteLine(f1.NUMERO+" "+f1.CONCEPTO);
            Console.ReadLine();
        }
    }
}
