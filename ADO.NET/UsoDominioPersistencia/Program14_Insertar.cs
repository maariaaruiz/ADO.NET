﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Persistencia;
using ADO.NET.Dominio;

namespace ADO.NET
{
    class Program14_Insertar
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            repositorio.Insertar(new Factura(20, "Tablet"));
            Console.ReadLine();
        }
    }
}