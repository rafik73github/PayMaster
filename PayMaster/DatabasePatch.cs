using System;
using System.IO;
using System.Data.SQLite;

namespace PayMaster
{
    class DatabasePatch
    {

            public static string GetDatabasePatch()
        {
            string dbPath = Environment.CurrentDirectory + "\\DATABASE";
            string dbFilePath;
            if (!string.IsNullOrEmpty(dbPath) && !Directory.Exists(dbPath))
                Directory.CreateDirectory(dbPath);
            dbFilePath = dbPath + "\\db_master.db";
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }

            string strCon = string.Format("Data Source={0};", dbFilePath);
            return strCon;
        }



    }
}
