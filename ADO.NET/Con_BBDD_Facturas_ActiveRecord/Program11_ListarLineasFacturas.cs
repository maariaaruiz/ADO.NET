
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
           // LineasFactura_ActiveRecord f1 = new LineasFactura_ActiveRecord();
            //f1.Borrar(1);

            //MIRAR
            //para INSERTAR linea factura
            LineasFactura_ActiveRecord lf1 = new LineasFactura_ActiveRecord(5,FacturaActiveRecord.BuscarUno(2).NUMERO,"1",4);
            // lf1.Insertar();



            FacturaActiveRecord f = FacturaActiveRecord.BuscarUno(2);

            List<LineasFactura_ActiveRecord> lista = f.BuscarLineasFactura();
            foreach (LineasFactura_ActiveRecord l in lista)
            {
                Console.WriteLine(l.Numero + " " + l.Productos_id);
            }



            Console.ReadLine();
        }
    }
}
