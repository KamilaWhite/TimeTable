/**using System;
using System.Data.SQLite;

namespace TimeTableCopy
{
    class ProgramCopy
    {
        static void Main(string[] args)
        {
  
            Database databaseObject = new Database();

            string queryToday = "SELECT * FROM myCalendar WHERE eventDate=date('now')";
            SQLiteCommand selectSpecificDateCommand = new SQLiteCommand(queryToday, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader resultToday = selectSpecificDateCommand.ExecuteReader();


            if (resultToday.HasRows)
            {
                while (resultToday.Read())
                {
                    Console.WriteLine("You don't have any events for today");
                }
            }
            //databaseObject.CloseConnection();// kiedy ma byc closeConnection? Po kazdym insercie czy przy zamykaniu  aplikacji?

            Console.WriteLine("Rows /Added : {0}", resultToday);
            //Console.ReadKey();

            Console.WriteLine("Hello Kamila today is " + (DateTime.Now).ToLongDateString());
            Console.WriteLine("Calendar events for today: " + resultToday);

            while (resultToday.Read())
            {
                Console.WriteLine("date: " + resultToday.GetValue(1).ToString()); ;
                
            }



          
            string choseAction;
            Console.WriteLine("Select the number of the action you want to perform:" + "1" + ". Would you like to view all events? " + "2" + "Add a new event to the calendar");
            choseAction = Console.ReadLine();
            Console.WriteLine("You chose: " + choseAction);

            if (choseAction != "2")
            {
                string queryAllEvents = "SELECT * FROM myCalendar";
                SQLiteCommand selectAllCommand = new SQLiteCommand(queryAllEvents, databaseObject.myConnection);
                databaseObject.OpenConnection();
                SQLiteDataReader resultAll = selectAllCommand.ExecuteReader();
                if (resultAll.HasRows)
                {
                    while (resultAll.Read())
                    {
                        Console.WriteLine("Event Data: {0} - Event Name: {1}", resultAll["eventDate"], resultAll["eventName"]);
                    }
                }
                databaseObject.CloseConnection();

                Console.ReadKey();
            }
            else
                {
                string query = "INSERT INTO myCalendar (`eventDate`, `eventName`) VALUES (@eventDate, @eventName)";//potem to usun
                SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
                databaseObject.OpenConnection();

                myCommand.Parameters.AddWithValue("@eventDate", "2021-09-21"); 
                myCommand.Parameters.AddWithValue("@eventName", "My internship program presentation"); 


                var result = myCommand.ExecuteNonQuery();
                databaseObject.CloseConnection();

                Console.WriteLine("Rows /Added : {0}", result);
                Console.ReadKey();
            }
        }
    }
}
**/