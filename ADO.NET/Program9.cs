using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program9
    {
        static void Main(string[] args)
        {
            List<FacturaActiveRecord> lista = FacturaActiveRecord.BuscarPorConcepto("Cosa");
            foreach(FacturaActiveRecord f in lista)
            {
                Console.WriteLine(f.NUMERO + " " + f.CONCEPTO);
            }
           
           
            Console.ReadLine();
        }
    }
}
