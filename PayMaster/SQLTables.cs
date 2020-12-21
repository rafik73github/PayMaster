using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PayMaster
{
    class SQLTables
    {
        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLTables()
        {
            sqlConnection = new SQLiteConnection(DatabasePatch.GetDatabasePatch());
            sqlConnection.Open();
            command = sqlConnection.CreateCommand();
        }




        public void ExecuteQuery(string sqlCommand)
        {

            SQLiteCommand triggerCommand = sqlConnection.CreateCommand();
            triggerCommand.CommandText = sqlCommand;
            triggerCommand.ExecuteNonQuery();
        }

        public void CreateTableTransactions()
        {
            
            string sqlCommand = "CREATE TABLE IF NOT EXISTS transactions" +
            "(" +
            "tr_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " tr_date STRING," +
            " tr_person_id INTEGER," +
            " tr_amount INTEGER," +
            " tr_pay_in BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }

        public void CreateTablePersons()
        {
            
            string sqlCommand = "CREATE TABLE IF NOT EXISTS persons" +
            "(" +
            "person_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " person_name STRING," +
            " person_surname STRING," +
            " person_archived BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }



    }
}
