using System;
using System.Collections.Generic;

namespace Semicrol.Cursos.Dominio
{
    public class Factura
    {
        public int NUMERO { get; set; }
        public string CONCEPTO { get; set; }
        public List<LineaFactura> lineas { get; set; }
        public Factura(int nUMERO)
        {
            NUMERO = nUMERO;
            lineas = new List<LineaFactura>();
        }

        public Factura(int nUMERO, string cONCEPTO)
        {
            NUMERO = nUMERO;
            CONCEPTO = cONCEPTO;
        }

        public void AddLinea(LineaFactura linea)
        {
            this.lineas.Add(linea);
        }
        public void RemoveLinea(LineaFactura linea)
        {
            this.lineas.Remove(linea);
        }



        public override bool Equals(object obj)
        {
            var factura = obj as Factura;
            return factura != null &&
                   NUMERO == factura.NUMERO;
        }

        public override int GetHashCode()
        {
            return -1856328427 + NUMERO.GetHashCode();
        }
    }
}
