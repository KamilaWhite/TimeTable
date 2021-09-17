using System;
using System.Data.SQLite;

namespace TimeTable
{
    class Program
    {
        private Database databaseObject;
        static void Main(string[] args)
        {
            Console.WriteLine("Project myCalendar in C#\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Hello Kamila today is " + (DateTime.Now).ToLongDateString());
            Console.WriteLine();
            Console.WriteLine("Calendar events for today: ");
            var currentDay = DateTime.Now.ToString("yyyy-MM-dd");
            showEventsByDay(currentDay);

            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            // Ask the user to choose an option.
            Console.WriteLine("What would you like to do, please select from the list:");
            Console.WriteLine("\ta - View all saved events");
            Console.WriteLine("\tb - Display selected date");
            Console.WriteLine("\tc - Add a new event to the calendar");
            Console.WriteLine("\td - Close myCalendar Project");
            Console.Write("You option? ");
            // Use a switch statement to do the math.
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    ShowAllEvents();
                    break;
                case "b":
                    SelectOneDay();
                    break;
                case "c":
                    AddEvents();
                    break;
                case "d":
                    CloseCalendar();
                    break;
            }
        }

        static void ShowAllEvents()
        {
            // View chosed option
            Console.WriteLine("You chose: View all saved events");
            Console.WriteLine();
            Console.WriteLine("Here is a list of saved events: ");
            // View all saved events
            Database databaseObject = new Database();

            string queryAllEvents = "SELECT * FROM myCalendar ORDER BY eventDate ASC";
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
            ShowMenu();
        }

        // Display selected date
        static void SelectOneDay()
        {
            // View chosed option
            string enteredDay;
            Console.WriteLine("Enter the date in the format YYYY-MM-DD: ");
            enteredDay = Console.ReadLine();

            showEventsByDay(enteredDay);
            ShowMenu();
        }

        static void showEventsByDay(string enteredDay)
        {
            // Search and display the selected date
            Database databaseObject = new Database();

            string query = $"SELECT * FROM myCalendar WHERE eventDate='{enteredDay}'";

            SQLiteCommand selectOneDayCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader resultFromOneDay = selectOneDayCommand.ExecuteReader();
            if (resultFromOneDay.HasRows)
            {
                while (resultFromOneDay.Read())
                {
                    Console.WriteLine("Event Data: {0} - Event Name: {1}", resultFromOneDay["eventDate"], resultFromOneDay["eventName"]);
                }
            }
        }

        static void AddEvents()
        {
            // Add event to The calendar
            Database databaseObject = new Database();

            string query = "INSERT INTO myCalendar (`eventDate`, `eventName`) VALUES (@eventDate, @eventName)";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);

            databaseObject.OpenConnection();

            string eventDate;
            Console.WriteLine("Enter the day in the format YYYY-MM-DD: ");
            eventDate = Console.ReadLine();
            myCommand.Parameters.AddWithValue("@eventDate", eventDate);

            string eventName;
            Console.WriteLine("Enter a name for the event: ");
            eventName = Console.ReadLine();
            myCommand.Parameters.AddWithValue("@eventName", eventName);

            var result = myCommand.ExecuteNonQuery();
            Console.WriteLine("Rows /Added : {0}", result);
            Console.WriteLine("Do you want to add a new event? Y/N: ");
            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                    AddEvents();
                    break;
                case "N":
                    ShowMenu();
                    break;
            }  
        }

        static void CloseCalendar()
        {
            // Wait for the user to respond before closing.
            Console.WriteLine();
            Console.Write("Please come back at any time");
            Console.WriteLine();
        }
    }
}
