using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PayMaster.SQL
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
            " person_nick STRING," +
            " person_archived BOOLEAN" +
            ")";
            ExecuteQuery(sqlCommand);


        }
        

        public void AddPerson(PersonModel person)
        {
           
            string sqlCommand = "INSERT INTO persons" +
            " (person_name, person_surname, person_nick, person_archived)" +
            " values" +
            " (" +
            "'" + person.PersonName + "', '" + person.PersonSurname + "', '" + person.PersonNick + "', " + person.PersonArchived +
            ")";
           ExecuteQuery(sqlCommand);

        }


        public void UpdatePerson(PersonModel person)
        {
            string personName = person.PersonName.ToUpper();
            string personSurname = person.PersonSurname.ToUpper();
            string personNick = person.PersonNick.ToUpper();

            string sqlCommand = "UPDATE persons" +
                " SET" +
                " person_name = " + "'" + personName + "'," +
                " person_surname = " + "'" + personSurname + "'," +
                " person_nick = " + "'" + personNick + "'," +
                " person_archived = " + person.PersonArchived +
                " WHERE person_id = " + person.PersonId;
            ExecuteQuery(sqlCommand);
        }

        public bool IsPersonExist(string name, string surname, string nick)
        {
            command.CommandText = "SELECT COUNT" +
                " (*)" +
                " FROM persons " +
                " WHERE " +
                " person_name = " + "'" + name + "'" +
                " AND person_surname = " + "'" + surname + "'" +
                " AND person_nick = " + "'" + nick + "'";

            int count = Convert.ToInt32(command.ExecuteScalar());

            if(count == 0)
            {
                return false;
            }

            return true;
        }


        public List<PersonModel> GetAllPersons()
        {
            List<PersonModel> result = new List<PersonModel>();

            command.CommandText = "SELECT" +
                " *" +
                " FROM persons" +
                " ORDER BY person_name ASC";
                

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                result.Add(new PersonModel(Convert.ToInt32(reader["person_id"]),
                    reader["person_name"].ToString(),
                    reader["person_surname"].ToString(),
                    reader["person_nick"].ToString(),
                    Convert.ToBoolean(reader["person_archived"])));
                

            }
            reader.Close();

            return result;

        }

        



    }
}
