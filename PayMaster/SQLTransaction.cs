﻿using System;
using System.Collections.Generic;
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
            " tr_target INTEGER," +
            " tr_description STRING," +
            " tr_pay_in BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }

        public void AddTransaction(Transaction transaction)
        {
            int amount = Convert.ToInt32(transaction.TransactionAmount * 100);
            if(transaction.TransactionPayIn == false) { amount *= -1; }
            string sqlCommand = "INSERT INTO transactions" +
            " (tr_date, tr_person_id, tr_amount, tr_target, tr_description, tr_pay_in)" +
            " values" +
            " (" +
            "'" + transaction.TransactionDate + "', " 
            + transaction.TransactionPersonId + ", " 
            + amount + ", "
            + transaction.TransactionTarget + ", "
            + "'" + transaction.TransactionDescription + "', "
            + transaction.TransactionPayIn +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public List<Transaction> GetAllTransactionList()
        {
            List<Transaction> result = new List<Transaction>();
            double convertedMoney;
            
            command.CommandText = "SELECT" +
                " a.tr_id AS a_tr_id," +
                " a.tr_date AS a_tr_date," +
                " a.tr_person_id AS a_tr_person_id," +
                " a.tr_amount AS a_tr_amount," +
                " a.tr_target AS a_tr_target," +
                " a.tr_description AS a_tr_description," +
                " a.tr_pay_in AS a_tr_pay_in," +
                " b.person_name AS b_person_name," +
                " b.person_surname AS b_person_surname," +
                " b.person_nick AS b_person_nick," +
                " c.pay_target_text AS c_pay_target_text" +
                " FROM transactions AS a" +
                " LEFT JOIN persons AS b ON a.tr_person_id = b.person_id" +
                " LEFT JOIN pay_target AS c ON a.tr_target = c.pay_target_id ORDER BY" +
                " a.tr_date ASC";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                convertedMoney = (Convert.ToDouble(reader["a_tr_amount"])) / 100;
                
                result.Add(new Transaction(Convert.ToInt32(reader["a_tr_id"]),
                                           reader["a_tr_date"].ToString(),
                                           Convert.ToInt32(reader["a_tr_person_id"]),
                                           reader["b_person_name"].ToString(),
                                           reader["b_person_surname"].ToString(),
                                           reader["b_person_nick"].ToString(),
                                           convertedMoney,
                                           Convert.ToInt32(reader["a_tr_target"]),
                                           reader["c_pay_target_text"].ToString(),
                                           reader["a_tr_description"].ToString(),
                                           Convert.ToBoolean(reader["a_tr_pay_in"])));

              

            }
            reader.Close();

            return result;
        }

      

        public double getAccountBalance()
        {
            double result;

            command.CommandText = "SELECT" +
                " SUM(tr_amount)" +
                " FROM transactions";
            object eScalar = command.ExecuteScalar();
            if (eScalar != DBNull.Value)
            {
                int amountSum = Convert.ToInt32(command.ExecuteScalar());
                result = (Convert.ToDouble(amountSum)) / 100;
            }
            else
            {
                result = 0;
            }
            
            return result;
        }



    }
}
