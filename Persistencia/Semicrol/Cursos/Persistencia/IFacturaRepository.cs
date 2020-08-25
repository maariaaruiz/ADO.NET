using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia.Filtros;

namespace Semicrol.Cursos.Persistencia
{//OPERACIONES A LA BBDD
    public interface IFacturaRepository
    {//implementa los metodos del repositorio
        void Insertar(Factura factura);
        void Borrar(Factura factura);
        void Actualizar(Factura factura);
        List<Factura> BuscarTodos();
        List<Factura> BuscarTodos(FiltroFactura2 filtro);
        Factura BuscarUno(int num);
    }
}
