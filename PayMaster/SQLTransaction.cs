using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PayMaster
{
    class SQLTransaction
    {
        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLTransaction()
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

        public void AddTransaction(Transaction transaction)
        {

            string sqlCommand = "INSERT INTO transactions" +
            " (tr_date, tr_person_id, tr_amount, tr_pay_in)" +
            " values" +
            " (" +
            "'" + transaction.TransactionDate + "', " + transaction.TransactionPersonId + ", " + transaction.TransactionAmount + ", " + transaction.TransactionPayIn +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public void GetAllTransaction()
        {

            double convertedMoney;
            command.CommandText = "SELECT" +
                " a.tr_id AS a_tr_id," +
                " a.tr_date AS a_tr_date," +
                " a.tr_person_id AS a_tr_person_id," +
                " a.tr_amount AS a_tr_amount," +
                " a.tr_pay_in AS a_tr_pay_in," +
                " b.person_name AS b_person_name," +
                " b.person_surname AS b_person_surname" +
                " FROM transactions AS a" +
                " LEFT JOIN persons AS b ON a.tr_person_id = b.person_id";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                convertedMoney = Convert.ToDouble(reader["a_tr_amount"]) / 100;

                Console.WriteLine("data: " + reader["a_tr_date"]
                    + " |imię: " + reader["b_person_name"]
                    + " |nazwisko: " + reader["b_person_surname"]
                    + " |kwota: " + String.Format("{0:N2}",convertedMoney)
                    + " |wpłata: " + reader["a_tr_pay_in"]
                    + " |person_id: " + reader["a_tr_person_id"]
                    + " |transaction_id: " + reader["a_tr_id"]);

            }
            reader.Close();


        }

        public void GetTransactionByDate(string date)
        {

            double convertedMoney;
            command.CommandText = "SELECT" +
                " a.tr_id AS a_tr_id," +
                " a.tr_date AS a_tr_date," +
                " a.tr_person_id AS a_tr_person_id," +
                " a.tr_amount AS a_tr_amount," +
                " a.tr_pay_in AS a_tr_pay_in," +
                " b.person_name AS b_person_name," +
                " b.person_surname AS b_person_surname" +
                " FROM transactions AS a" +
                " LEFT JOIN persons AS b ON a.tr_person_id = b.person_id" +
                " WHERE a.tr_date = '" + date + "'";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                convertedMoney = Convert.ToDouble(reader["a_tr_amount"]) / 100;

                Console.WriteLine("data: " + reader["a_tr_date"]
                    + " |imię: " + reader["b_person_name"]
                    + " |nazwisko: " + reader["b_person_surname"]
                    + " |kwota: " + String.Format("{0:N2}", convertedMoney)
                    + " |wpłata: " + reader["a_tr_pay_in"]
                    + " |person_id: " + reader["a_tr_person_id"]
                    + " |transaction_id: " + reader["a_tr_id"]);

            }
            reader.Close();


        }

        public void GetTransactionByPerson(int personId)
        {

            double convertedMoney;
            command.CommandText = "SELECT" +
                " a.tr_id AS a_tr_id," +
                " a.tr_date AS a_tr_date," +
                " a.tr_person_id AS a_tr_person_id," +
                " a.tr_amount AS a_tr_amount," +
                " a.tr_pay_in AS a_tr_pay_in," +
                " b.person_name AS b_person_name," +
                " b.person_surname AS b_person_surname" +
                " FROM transactions AS a" +
                " LEFT JOIN persons AS b ON a.tr_person_id = b.person_id" +
                " WHERE a.tr_person_id = " + personId;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                convertedMoney = Convert.ToDouble(reader["a_tr_amount"]) / 100;

                Console.WriteLine("data: " + reader["a_tr_date"]
                    + " |imię: " + reader["b_person_name"]
                    + " |nazwisko: " + reader["b_person_surname"]
                    + " |kwota: " + String.Format("{0:N2}", convertedMoney)
                    + " |wpłata: " + reader["a_tr_pay_in"]
                    + " |person_id: " + reader["a_tr_person_id"]
                    + " |transaction_id: " + reader["a_tr_id"]);

            }
            reader.Close();


        }

        public void GetTransactionByPayment(bool payment)
        {

            double convertedMoney;
            command.CommandText = "SELECT" +
                " a.tr_id AS a_tr_id," +
                " a.tr_date AS a_tr_date," +
                " a.tr_person_id AS a_tr_person_id," +
                " a.tr_amount AS a_tr_amount," +
                " a.tr_pay_in AS a_tr_pay_in," +
                " b.person_name AS b_person_name," +
                " b.person_surname AS b_person_surname" +
                " FROM transactions AS a" +
                " LEFT JOIN persons AS b ON a.tr_person_id = b.person_id" +
                " WHERE a.tr_pay_in = " + payment;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                convertedMoney = Convert.ToDouble(reader["a_tr_amount"]) / 100;

                Console.WriteLine("data: " + reader["a_tr_date"]
                    + " |imię: " + reader["b_person_name"]
                    + " |nazwisko: " + reader["b_person_surname"]
                    + " |kwota: " + String.Format("{0:N2}", convertedMoney)
                    + " |wpłata: " + reader["a_tr_pay_in"]
                    + " |person_id: " + reader["a_tr_person_id"]
                    + " |transaction_id: " + reader["a_tr_id"]);

            }
            reader.Close();


        }



    }
}
