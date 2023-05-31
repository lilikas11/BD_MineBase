using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineBase_final
{
    public class DatabaseHelper
    {
        public static SqlConnection getSGBDConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
            builder.InitialCatalog = "p8g5";
            builder.UserID = "p8g5";
            builder.Password = "pro.gram.mer";
            return new SqlConnection(builder.ConnectionString);
        }

        public static bool verifySGBDConnection(SqlConnection cn)
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
    }
}
