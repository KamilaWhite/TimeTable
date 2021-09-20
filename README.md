# myCalendar app in C#

The purpose of the project was to learn the **C# language** by creating an application nameded myCalendar. 
In the project, I used a connection to the `SQLite database`, which is located in the folder `“example-db”`.
___
### How it works
When starting the application, you can see the **Welcome module**  with today's date and calendar events, if they are saved for today. 

![Welcome module](https://github.com/KamilaWhite/TimeTable/blob/main/attachments/Welcome%20module1.PNG?raw=true)

 
Then we can see a module with four options to choose from. 

![](https://github.com/KamilaWhite/TimeTable/blob/main/attachments/menu.PNG?raw=true)

___
**A.** If we select **"View all saved events"** on the console screen, we will see all the events entered into the database along with the dates.

![](https://github.com/KamilaWhite/TimeTable/blob/main/attachments/allEvents.PNG?raw=true)

___
**B.** If we choose **"Display selected date"**, the program will ask us to enter the date we are interested in. And then it will display our saved events, if there are no events for that day, we will be informed about it.

 ![](https://github.com/KamilaWhite/TimeTable/blob/main/attachments/selectDay.PNG?raw=true)
___

**C.** If we choose the **"Add a new event to the calendar"** option, the program will direct us to save the new event to the database. It will ask for the date and name of the event. After saving the item, we will be informed about this and the program will ask if we want to add another line.

![](https://github.com/KamilaWhite/TimeTable/blob/main/attachments/addNewEvents.PNG?raw=true)
___

**D.** We can also choose the **"Close my Calendar Project"** option. If, for example, we just wanted to check the events for today and not take any additional actions.

![](https://github.com/KamilaWhite/TimeTable/blob/main/attachments/cleseApp.PNG?raw=true)
___

After each action, of course, except the last one where the application is closed, a selection module is displayed, **which gives us flexibility**.
___
*In the future, I would like to change the concept a bit and write the program more object-oriented.*
