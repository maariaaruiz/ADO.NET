using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Persistencia
{
   public interface ILineaFacturaRepository
    {
        void Insertar(LineaFactura linea);
        void Borrar(LineaFactura linea);
        void Actualizar(LineaFactura linea);
        List<LineaFactura> BuscarTodasLineas();
        LineaFactura BuscarUnaLinea(int num);

    }
}
