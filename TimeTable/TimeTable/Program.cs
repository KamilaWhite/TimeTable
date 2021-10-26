using System;

namespace TimeTable
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Project myCalendar in C#\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Hello Kamila today is " + (DateTime.Now).ToLongDateString());
            Console.WriteLine();
            Console.WriteLine("Calendar events for today: ");
            var currentDay = DateTime.Now.ToString("yyyy-MM-dd");

            Events events = new Events();
            events.Open();

            events.ShowEventsByDay(currentDay);
            ShowMenu(events);

            events.Close();
        }

        private static void ShowMenu(Events events)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do, please select from the list:");
            Console.WriteLine("\tA - View all saved events");
            Console.WriteLine("\tB - Display selected date");
            Console.WriteLine("\tC - Add a new event to the calendar");
            Console.WriteLine("\tD - Close myCalendar Project");
            Console.Write("Your option? ");

            switch (Console.ReadLine().ToUpper())
            {
                case "A":
                    events.ShowAll(); 
                    ShowMenu(events);
                    break;
                case "B":
                    events.SelectOneDay();
                    ShowMenu(events);
                    break;
                case "C":
                    events.AddEvents();
                    ShowMenu(events);
                    break;
                case "D":
                    events.CloseCalendar();
                    break;
            }
        }
    }
}
