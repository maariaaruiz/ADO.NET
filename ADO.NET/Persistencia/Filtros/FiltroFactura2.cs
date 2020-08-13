using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Persistencia.Filtros
{
    class FiltroFactura2
    {
 
        private int _numero;
        private string _concepto;

        private FiltroFactura2()
        {

        }

        public int Numero
        {
            get { return _numero; } 
        }

        public string Concepto
        {
            get { return _concepto; }

        }

        public void AddNumero(int numero)
        {
            this._numero = Numero;
        }
        public void AddConcepto(string concepto)
        {
           this._concepto=Concepto;
        }

        
    }
}
