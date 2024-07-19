using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_system
{
    internal class Function
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=AHSAN\AHSAN;Initial Catalog=db_login;Integrated Security=True;");
        public static string id_user = "";
        public static string tipe_user = "";
    }
}
