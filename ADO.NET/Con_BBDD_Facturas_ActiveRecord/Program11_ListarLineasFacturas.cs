using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program11_ListarLineasFacturas
    {
        static void Main(string[] args)
        {
            //para borrar linea factura
            LineasFactura f1 = new LineasFactura();
            f1.Borrar(5);

            //para INSERTAR linea factura
            //  LineasFactura lf1= new LineasFactura(5,FacturaActiveRecord.BuscarUno(2),"1",4);
            // lf1.Insertar();



            FacturaActiveRecord f = FacturaActiveRecord.BuscarUno(2);

            List<LineasFactura> lista = f.BuscarLineasFactura();
            foreach (LineasFactura l in lista)
            {
               Console.WriteLine( l.Numero+" "+l.Productos_id);
            }
       


            Console.ReadLine();
        }
    }
}
