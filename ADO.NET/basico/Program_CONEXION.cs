using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program_CONEXION
    {
        static void Main(string[] args)
        {
            //conexion a bdd prueba
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\formacion\Documents\Facturas.mdf;Integrated Security=True;Connect Timeout=30");
            conexion.Open();

            string sql = "select * from Facturas";
            SqlCommand comando = new SqlCommand(sql, conexion);
            SqlDataReader lector= comando.ExecuteReader();

            while(lector.Read())
            {
                Console.WriteLine(lector["NUMERO"].ToString());
                Console.WriteLine(lector["CONCEPTO"].ToString());
            }
            Console.ReadLine();
        }
    }
}
