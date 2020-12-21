using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PayMaster
{
    class SQLActions
    {


        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLActions()
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

        

        public void AddTransaction(Person person, double money, bool payment)
        {
            
            int converted = Convert.ToInt32(money * 100);

            string sqlCommand = "INSERT INTO my_table" +
            " (name, surname, money, payment)" +
            " values" +
            " (" +
            "'" + person.PersonName + "', '" + person.PersonSurname + "', " + converted + ", " + payment +
            ")";
            ExecuteQuery(sqlCommand);

        }

        public void ReadAllTransaction()
        {
            
            double convertedMoney;
            command.CommandText = "SELECT" +
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
                    + " |kwota: " + convertedMoney 
                    + " |wpłata: " + reader["a_tr_pay_in"]
                    + " |person_id: " + reader["a_tr_person_id"]);

            }
            reader.Close();


        }

        public void AddPerson(Person person)
        {
           
            string sqlCommand = "INSERT INTO persons" +
            " (person_name, person_surname, person_archived)" +
            " values" +
            " (" +
            "'" + person.PersonName + "', '" + person.PersonSurname + "', " + person.PersonArchived +
            ")";
           ExecuteQuery(sqlCommand);

        }

        public void ReadAllPersons()
        {
           
            command.CommandText = "SELECT" +
                " *" +
                " FROM persons";
                

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               

                Console.WriteLine("person_id: " + reader["person_id"]
                    + " |imię: " + reader["person_name"]
                    + " |nazwisko: " + reader["person_surname"]
                    );

            }
            reader.Close();


        }

    }
}
