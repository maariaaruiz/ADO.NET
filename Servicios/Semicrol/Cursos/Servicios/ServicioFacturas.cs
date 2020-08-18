using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Persistencia.Filtros;

namespace Semicrol.Cursos.Servicios
{
    public class ServicioFacturas:IServicioFacturacion
    {
        private IFacturaRepository repoFacturas;
        private ILineaFacturaRepository repoLineas;

        public ServicioFacturas(IFacturaRepository repoFacturas, ILineaFacturaRepository repoLineas)
        {
            this.repoFacturas = repoFacturas;
            this.repoLineas = repoLineas;
        }

        public void InsertarFactura(Factura f)
        {
            repoFacturas.Insertar(f);
            foreach (LineaFactura lf in f.lineas)
            {
                repoLineas.Insertar(lf);
            }
           
        }

        public List<Factura> BuscarTodasFacturas()
        {
            return repoFacturas.BuscarTodos();
        }

        public void BorrarFactura(Factura factura)
        {
            repoFacturas.Borrar(factura);
            foreach (LineaFactura lf in factura.lineas)
            {
                repoLineas.Borrar(lf);
            }
        }

        public void ActualizarFactura(Factura factura)
        {
            repoFacturas.Actualizar(factura);
        }

        public Factura BuscarUnaFactura(int num)
        {
          return repoFacturas.BuscarUno(num);
        }

        public List<Factura> BuscarTodasFacturasConLineas()
        {
            return repoFacturas.BuscarTodosConLineas();
        }

        public void InsertarLinea(LineaFactura linea)
        {
            repoLineas.Insertar(linea);
        }

        public void BorrarLinea(LineaFactura linea)
        {
            repoLineas.Borrar(linea);
        }

        public void ActualizarLinea(LineaFactura linea)
        {
            repoLineas.Actualizar(linea);
        }

        public List<LineaFactura> BuscarTodasLineas()
        {
            return repoLineas.BuscarTodasLineas();
        }

        public LineaFactura BuscarUnaLinea(int num)
        {
            return repoLineas.BuscarUnaLinea(num);
        }

        public List<Factura> BuscarTodasFacturasConFiltro(FiltroFactura2 filtro)
        {
            return repoFacturas.BuscarTodos(filtro);
        }
    }
}
