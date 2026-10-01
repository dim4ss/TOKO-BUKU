using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasir_TokoBuku
{
    internal class database
    {
        private static string connectionString =
           "Server=localhost;" +
           "Database=toko_buku;" +
           "Uid=root;" +
           "Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

