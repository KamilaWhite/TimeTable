using System.Data.SQLite;
using System.IO;

namespace TimeTable
{
    class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=myCalendar.sqlite3");
            if (!File.Exists("./myCalendar.sqlite3"))
            {
                SQLiteConnection.CreateFile("myCalendar.sqlite3");
                System.Console.WriteLine("Database file created");
            }
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}