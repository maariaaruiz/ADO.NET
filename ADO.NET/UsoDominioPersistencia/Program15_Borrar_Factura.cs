﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.PersistenciaADO;

namespace ADO.NET
{
    class Program15_Borrar_Factura
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            repositorio.Borrar(new Factura(20));
            Console.ReadLine();
        }
    }
}
