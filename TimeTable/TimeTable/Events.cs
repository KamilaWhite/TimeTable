using System;
using System.Data.SQLite;

namespace TimeTable
{
    public class Events
    {
        private Database _databaseObject;

        public void Open()
        {
            _databaseObject = new Database();
            _databaseObject.OpenConnection();
        }

        public void Close()
        {
            _databaseObject.CloseConnection();
        }

        public void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("Here is a list of saved events: ");

            // View all saved events
            string queryAllEvents = "SELECT * FROM myCalendar ORDER BY eventDate ASC";
            SQLiteCommand selectAllCommand = new SQLiteCommand(queryAllEvents, _databaseObject.myConnection);

            SQLiteDataReader resultAll = selectAllCommand.ExecuteReader();
            if (resultAll.HasRows)
            {
                while (resultAll.Read())
                {
                    Console.WriteLine("Event Data: {0} - Event Name: {1}", resultAll["eventDate"], resultAll["eventName"]);
                }
            }
        }

        public void SelectOneDay()
        {
            string eventDay;
            while ((eventDay = ParseDate()) == null)
                Console.WriteLine("The date format is incorrect");

            ShowEventsByDay(eventDay);
        }

        private string ParseDate()
        {
            string enteredDay;

            Console.WriteLine("Enter the date in the format YYYY-MM-DD: ");
            enteredDay = Console.ReadLine();

            if (DateTime.TryParse(enteredDay, out DateTime dateValue))
            {
                // ShowMenu();
                return enteredDay;
            }

            return null;
        }

        public void ShowEventsByDay(string enteredDay)
        {
            // Search and display the selected date

            string query = $"SELECT * FROM myCalendar WHERE eventDate='{enteredDay}'";

            SQLiteCommand selectOneDayCommand = new SQLiteCommand(query, _databaseObject.myConnection);

            SQLiteDataReader resultFromOneDay = selectOneDayCommand.ExecuteReader();
            if (resultFromOneDay.HasRows)
            {
                while (resultFromOneDay.Read())
                {
                    Console.WriteLine("Event Data: {0} - Event Name: {1}", resultFromOneDay["eventDate"], resultFromOneDay["eventName"]);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You have no events for this day");
            }
        }

        public void AddEvents()
        {
            // Add event to The calendar
            string query = "INSERT INTO myCalendar (`eventDate`, `eventName`) VALUES (@eventDate, @eventName)";
            SQLiteCommand myCommand = new SQLiteCommand(query, _databaseObject.myConnection);

            // Ask the user to enter a date
            string eventDate;
            while ((eventDate = ParseDate()) == null)
            {
                Console.WriteLine("The date format is incorrect");
            };

            myCommand.Parameters.AddWithValue("@eventDate", eventDate);

            // Ask user to enter a Event Name
            string eventName;
            Console.WriteLine("Enter a name for the event: ");
            eventName = Console.ReadLine();
            myCommand.Parameters.AddWithValue("@eventName", eventName);

            // Ask the user if he wants to enter further events
            var result = myCommand.ExecuteNonQuery();
            Console.WriteLine("Rows /Added : {0}", result);
            while (true)
            {
                Console.WriteLine("Do you want to add a new event? Y/N: ");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        AddEvents();
                        return;

                    case "N": 
                        return;
                }

                Console.WriteLine("The format is incorrect");
            }
        }

        public void CloseCalendar()
        {
            // Close application
            Console.WriteLine();
            Console.Write("myCalendar app will close. Please come back at any time");
            Console.WriteLine();
        }
    }
}
