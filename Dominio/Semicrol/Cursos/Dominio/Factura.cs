using System;

namespace Semicrol.Cursos.Dominio
{//ENTIDADES
    public class Factura
    {
        public int NUMERO { get; set; }
        public string CONCEPTO { get; set; }

        public Factura(int nUMERO)
        {
            NUMERO = nUMERO;
        }

        public Factura(int nUMERO, string cONCEPTO)
        {
            NUMERO = nUMERO;
            CONCEPTO = cONCEPTO;
        }

    }
}
