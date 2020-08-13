using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Dominio
{
    class LineaFactura
    {
        public int Numero { get; set; }
        public int Facturas_num { get; set; }
        public string Productos_id { get; set; }
        public int Unidades { get; set; }
   
    public LineaFactura(int numero, int facturas_num, string productos_id, int unidades)
    {
        Numero = numero;
        Facturas_num = facturas_num;
        Productos_id = productos_id;
        Unidades = unidades;
    }

        public LineaFactura()
        {
        }
    }
}
