﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PayMaster
{
    class SQLPerson
    {


        SQLiteConnection sqlConnection;
        SQLiteCommand command;

        public SQLPerson()
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

        public void GetAllPersons()
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