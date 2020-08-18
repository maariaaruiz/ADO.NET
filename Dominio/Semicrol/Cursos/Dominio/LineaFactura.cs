using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Dominio
{
   public class LineaFactura
    {
        public int Numero { get; set; }
        public string Productos_id { get; set; }
        public int Unidades { get; set; }
        public Factura factura { get; set; }
   

        //public LineaFactura()
        //{
        //}

        public LineaFactura(int numero, Factura factura)
        {
            Numero = numero;
            this.factura = factura;
        }

        public override bool Equals(object obj)
        {
            var factura = obj as LineaFactura;
            return factura != null &&
                   Numero == factura.Numero;
        }

        public override int GetHashCode()
        {
            return -1449941195 + Numero.GetHashCode();
        }
    }
}
