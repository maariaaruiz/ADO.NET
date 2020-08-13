using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Dominio
{
    class Factura
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
