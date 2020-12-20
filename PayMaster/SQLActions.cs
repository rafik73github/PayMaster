using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster
{
    class SQLActions
    {

        
        
        public static void AddData(Person person, double money, bool payment)
        {

            int converted = Convert.ToInt32(money * 100);

            string sqlCommand = "INSERT INTO my_table" +
            " (name, surname, money, payment)" +
            " values" +
            " (" +
            "'" + person.PersonName + "', '" + person.PersonSurname + "', " + converted + ", " + payment +
            ")";
            new SQLiteConn().ExecuteQuery(sqlCommand);

        }

    }
}
