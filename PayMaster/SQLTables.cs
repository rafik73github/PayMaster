using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster
{
    class SQLTables
    {

        public static void CreateTables()
        {

            string sqlCommand = "CREATE TABLE IF NOT EXISTS my_table" +
            "(" +
            "id_test INTEGER PRIMARY KEY AUTOINCREMENT," +
            " name STRING," +
            " surname STRING," +
            " money INTEGER," +
            " payment BOOLEAN" +
            ")";
            new SQLiteConn().ExecuteQuery(sqlCommand);


        }

    }
}
