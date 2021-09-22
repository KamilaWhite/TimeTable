using System;
using System.Data.SQLite;

namespace TimeTable
{
    class Program
    {
        //private Database databaseObject;
        static void Main(string[] args)
        {
            Console.WriteLine("Project myCalendar in C#\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Hello Kamila today is " + (DateTime.Now).ToLongDateString());
            Console.WriteLine();
            Console.WriteLine("Calendar events for today: ");
            var currentDay = DateTime.Now.ToString("yyyy-MM-dd");
            ShowEventsByDay(currentDay);
            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            // Ask the user to choose an option.
            Console.WriteLine("What would you like to do, please select from the list:");
            Console.WriteLine("\tA - View all saved events");
            Console.WriteLine("\tB - Display selected date");
            Console.WriteLine("\tC - Add a new event to the calendar");
            Console.WriteLine("\tD - Close myCalendar Project");
            Console.Write("Your option? ");
            // Use a switch statement to do the math.
            switch (Console.ReadLine().ToUpper())
            {
                case "A":
                    ShowAllEvents();
                    break;
                case "B":
                    SelectOneDay();
                    break;
                case "C":
                    AddEvents();
                    break;
                case "D":
                    CloseCalendar();
                    break;
            }
        }

        static void ShowAllEvents()
        {
            Console.WriteLine();
            Console.WriteLine("Here is a list of saved events: ");
            Database databaseObject = new Database();
            
            // View all saved events
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
            // Ask the user to enter any date
            string enteredDay;
            DateTime dateValue;

            Console.WriteLine("Enter the date in the format YYYY-MM-DD: ");
            enteredDay = Console.ReadLine();

            if (DateTime.TryParse(enteredDay, out dateValue))
            {
                ShowEventsByDay(enteredDay);
                ShowMenu();
            }
            else
                Console.WriteLine("The date format is incorrect", enteredDay);
                Console.WriteLine();
                Console.WriteLine("You want to enter the date again? Y/N: ");
                switch (Console.ReadLine().ToUpper())
                {
                case "Y":
                    SelectOneDay();
                    break;
                case "N":
                    ShowMenu();
                    break;
                }
        }

        static void ShowEventsByDay(string enteredDay)
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
            else
            {
                Console.WriteLine();
                Console.WriteLine("You have no events for this day");
            }
            
         }

        static void AddEvents()
        {
            // Add event to The calendar
            Database databaseObject = new Database();

            string query = "INSERT INTO myCalendar (`eventDate`, `eventName`) VALUES (@eventDate, @eventName)";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);

            databaseObject.OpenConnection();

            // Ask the user to enter a date 
            string eventDate;
            Console.WriteLine("Enter the day in the format YYYY-MM-DD: ");
            eventDate = Console.ReadLine();
            myCommand.Parameters.AddWithValue("@eventDate", eventDate);

            // Ask user to enter a Event Name
            string eventName;
            Console.WriteLine("Enter a name for the event: ");
            eventName = Console.ReadLine();
            myCommand.Parameters.AddWithValue("@eventName", eventName);

            // Ask the user if he wants to enter further events
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
            // Close application
            Console.WriteLine();
            Console.Write("myCalendar app will close. Please come back at any time");
            Console.WriteLine();
        }
    }
}
