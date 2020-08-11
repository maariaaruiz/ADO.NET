using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FacturaActiveRecord
    {
        public FacturaActiveRecord(int nUMERO, string cONCEPTO)
        {
            NUMERO = nUMERO;
            CONCEPTO = cONCEPTO;
        }

        public int NUMERO { get; set; }
        public string CONCEPTO { get; set; }

        public void Insertar()
        {
            SqlConnection conexion = new SqlConnection
                (@"");
            conexion.Open();
            string sql = "insert into Facturas VALUES ("+NUMERO+",'"+CONCEPTO+"')";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
