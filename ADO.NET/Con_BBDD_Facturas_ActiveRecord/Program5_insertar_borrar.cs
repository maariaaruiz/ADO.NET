﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program5_insertar_borrar
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f1 = new FacturaActiveRecord(4,"Televisor");
            f1.Insertar();
            // CON PARAMTROS
           //f1.Borrar(4);
            // SIN PARAMTROS
            f1.Borrar();
          
        }
    }
}
