﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Persistencia.Filtros;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.PersistenciaADO;
using Semicrol.Cursos.Servicios;

namespace ADO.NET
{
    class Program20
    {
        static void Main(string[] args)
        {
            
            IFacturaRepository repositorio = new FacturaRepository();
            ILineaFacturaRepository repolineas = new LineaFacturaRepository();
            IServicioFacturacion servicio = new ServicioFacturas(repositorio,repolineas);

            List<Factura> lista = servicio.BuscarTodasFacturas();

            foreach (Factura f in lista)
            {
                Console.WriteLine(f.CONCEPTO);
               /* foreach (LineaFactura lf in  f.lineas)
                {
                    Console.WriteLine(lf.Unidades);
                }*/
            }
            //borrar factura
           // servicio.BorrarFactura(repositorio.BuscarUno(2));
           
          
            Console.ReadLine();
        }
    }
}
