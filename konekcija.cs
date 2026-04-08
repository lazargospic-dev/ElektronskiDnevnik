using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace dnevnik410a
{
    internal class konekcija
    {
        public static SqlConnection povezi()
        {
            string CS;
            CS = ConfigurationManager.ConnectionStrings["kuca"].ConnectionString;
            SqlConnection veza = new SqlConnection(CS); 
            return veza;
        }
    }
}
