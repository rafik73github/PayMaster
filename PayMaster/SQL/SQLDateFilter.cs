using System;
using System.Collections.Generic;
using System.Data.SQLite;
using PayMaster.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster.SQL
{
    class SQLDateFilter
    {

        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLDateFilter()
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

        public void CreateTableDateFilter()
        {

            string sqlCommand = "CREATE TABLE IF NOT EXISTS date_filter" +
            "(" +
            "date_filter_id INTEGER PRIMARY KEY AUTOINCREMENT," +
            " date_filter_description STRING," +
            " date_filter_first_date STRING," +
            " date_filter_last_date STRING" +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public bool AddDateFilter(FilterModel dateFilterModel)
        {
            command.CommandText = "SELECT COUNT" +
                " (*)" +
                " FROM date_filter ";

            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count == 0)
            {
                return false;
            }
            else
            {
                string sqlCommand = "INSERT INTO date_filter" +
                " (date_filter_description, date_filter_first_date, date_filter_last_date)" +
                " values" +
                " (" +
                "'" + dateFilterModel.DateFilterDescription + "'," + dateFilterModel.DateFilterFirstDate + "'," + dateFilterModel.DateFilterLastDate +
                ")";
                ExecuteQuery(sqlCommand);
            }

            return true;
        }

        public void UpdateDateFilter(FilterModel dateFilterModel)
        {
            
            string sqlCommand = "UPDATE date_filter" +
                " SET" +
                " date_filter_description = " + "'" + dateFilterModel.DateFilterDescription + "'," +
                " date_filter_first_date = " + "'" + dateFilterModel.DateFilterFirstDate + "'," +
                " date_filter_last_date = " + "'" + dateFilterModel.DateFilterLastDate +
                " WHERE person_id = " + dateFilterModel.FilterId;
            ExecuteQuery(sqlCommand);
        }


        public List<FilterModel> GetDateFilter()
        {
            List<FilterModel> result = new List<FilterModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM date_filter";


            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new FilterModel(Convert.ToInt32(reader["date_filter_id"]),
                    reader["date_filter_description"].ToString(),
                    reader["date_filter_first_date"].ToString(),
                    reader["date_filter_last_date"].ToString()));

            }
            reader.Close();

            return result;

        }



    }
}
