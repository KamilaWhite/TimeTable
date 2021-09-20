# myCalendar app in C#

The purpose of the project was to learn the **C# language** by creating an application nameded myCalendar. 
In the project, I used a connection to the `SQLite database`, which is located in the folder `“example-db”`.
___
### How it works
When starting the application, you can see the **Welcome module** with today's date and calendar events, if they are saved for today. 
Then we can see a module with four options to choose from.

**A.** If we select **"View all saved events"** on the console screen, we will see all the events entered into the database along with the dates.

**B.** If we choose **"Display selected date"**, the program will ask us to enter the date we are interested in. And then it will display our saved events, if there are no events for that day, we will be informed about it.

**C.** If we choose the **"Add a new event to the calendar"** option, the program will direct us to save the new event to the database. After saving the item, we will be informed about this and the program will ask if we want to add another line.

**D.** We can also choose the **"Close my Calendar Project"** option. If, for example, we just wanted to check the events for today and not take any additional actions.

After each action, of course, except the last one where the application is closed, a selection module is displayed, **which gives us flexibility**.
___
*In the future, I would like to change the concept a bit and write the program more object-oriented.*
