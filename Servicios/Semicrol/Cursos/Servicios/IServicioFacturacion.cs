using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Servicios
{
    //clases de servicio - patron fachada
    //la clase implementa el interfaz, este se apoya en otros 2 interfaces
    //agrupan la funcionalidad de ambos repositorios
    //para no tener q trabajar con tantos repositorios, los agrupamos en servicios

    public interface IServicioFacturacion
    {
        void InsertarFactura(Factura factura);
        //void Borrar(Factura factura);
        //void Actualizar(Factura factura);
        List<Factura> BuscarTodasFacturas();
        //List<Factura> BuscarTodos(FiltroFactura2 filtro);
        //Factura BuscarUno(int num);

        //List<Factura> BuscarTodosConLineas();
        //void Insertar(LineaFactura linea);
        //void Borrar(LineaFactura linea);
        //void Actualizar(LineaFactura linea);
        //List<LineaFactura> BuscarTodasLineas();
        //LineaFactura BuscarUnaLinea(int num);

        
    }
}
