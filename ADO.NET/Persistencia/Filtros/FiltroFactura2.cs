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

        public int Numero
        {
            get { return _numero; } 
        }

        public string Concepto
        {
            get { return _concepto; }

        }

        //programacion fluida
        public FiltroFactura2 AddNumero(int numero)
        {
            this._numero = Numero;
            return this;
        }
        public FiltroFactura2 AddConcepto(string concepto)
        {
           this._concepto=Concepto;
            return this;
        }

        
    }
}
