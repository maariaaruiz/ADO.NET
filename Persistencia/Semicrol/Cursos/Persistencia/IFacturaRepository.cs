using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Semicrol.Cursos.Persistencia.Filtros;
using Semicrol.Cursos.Dominio;

namespace Semicrol.Cursos.Persistencia
{
    public interface IFacturaRepository
    {
        void Insertar(Factura factura);
        void Borrar(Factura factura);
        void Actualizar(Factura factura);
        List<Factura> BuscarTodos();
        List<Factura> BuscarTodos(FiltroFactura2 filtro);
        Factura BuscarUno(int num);
    }
}
