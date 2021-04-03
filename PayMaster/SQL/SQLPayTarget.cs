using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace PayMaster.SQL
{
    class SQLPayTarget
    {

        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLPayTarget()
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

        public void CreateTablePayTarget()
        {

            string sqlCommand = "CREATE TABLE IF NOT EXISTS pay_target" +
            "(" +
            "pay_target_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " pay_target_text STRING," +
            " pay_target_archived BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public void AddPayTarget(PayTargetModel payTarget)
        {

            string sqlCommand = "INSERT INTO pay_target" +
            " (pay_target_text, pay_target_archived)" +
            " values" +
            " (" +
            "'" + payTarget.PayTargetText + "'," + payTarget.PayTargetArchived +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public List<PayTargetModel> GetAllPayTargets()
        {
            List<PayTargetModel> result = new List<PayTargetModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM pay_target" +
                " ORDER BY pay_target_text ASC";


            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new PayTargetModel(Convert.ToInt32(reader["pay_target_id"]),
                    reader["pay_target_text"].ToString(),
                    Convert.ToBoolean(reader["pay_target_archived"])));


            }
            reader.Close();

            return result;

        }

        public List<PayTargetModel> GetPayTarget()
        {
            List<PayTargetModel> result = new List<PayTargetModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM pay_target" +
                " ORDER BY pay_target_text ASC";


            SQLiteDataReader reader = command.ExecuteReader();

            result.Add(new PayTargetModel(-1, "WSZYSTKIE"));

            while (reader.Read())
            {

                result.Add(new PayTargetModel(Convert.ToInt32(reader["pay_target_id"]),
                    reader["pay_target_text"].ToString()
                    ));


            }
            reader.Close();

            return result;

        }

        public bool IsTargetExist(string target)
        {
            command.CommandText = "SELECT COUNT" +
                " (*)" +
                " FROM pay_target " +
                " WHERE " +
                " pay_target_text = " + "'" + target + "'";

            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count == 0)
            {
                return false;
            }

            return true;
        }

    }
}
