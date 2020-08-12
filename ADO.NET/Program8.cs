using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program8
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f1 = FacturaActiveRecord.BuscarUno(2);
            f1.CONCEPTO = "Cosa";
            f1.Actualizar();
            Console.WriteLine(f1.NUMERO+" "+f1.CONCEPTO);
           
            Console.ReadLine();
        }
    }
}
