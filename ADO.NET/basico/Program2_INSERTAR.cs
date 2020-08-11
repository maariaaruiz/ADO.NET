using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program2_INSERTAR
    {
        static void Main(string[] args)
        {
            //conexion a bdd prueba
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\formacion\Documents\Facturas.mdf;Integrated Security=True;Connect Timeout=30");
            conexion.Open();

            string sql = "insert into Facturas VALUES (3,'Otra')";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery(); 
            Console.ReadLine();
        }
    }
}
