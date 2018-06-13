# EventManager_Maria_Marinova - ASP.NET Core MVC Web Application
The project was made using Visual Studio 2017

Setup Guide
1. Open the project with Visual Studio 2017

2. Click on Rebuild Solution

3. Setting the connection string - in the appsettings.json file in the section "ConnectionStrings", then in "DefaultConnection"
you should set up the connection string. I have tested the app with the SQL server LocalDB.

4. Open the Package Manager Console in Visual Studio, go to the section Default Project and change it to EventManager.Data

5. Write the command Add-Migration InitCreate

6. Write the command Update-Database

7. The previous commands will create the database and the migrations.

8. Then start the app from the button in the upper section in Visual Studio - the button shows IIS Express - 
change this to EventManager.Web  

9. In order to be able to add a new event, you have to register - click register in the upper right corner on the home page and register
with some sample email and password.

10. Then log in.

11. Click on the section "Add Event" and add some new event.

12. Logged-in users have the option to view their own events from the section "Your Events"

13. Each user can edit and remove only his/her own events from the section "Your Events".

14. All the events by all users are listed on the home page.

I have first created a blank solution in which I added the ASP.NET Core Web App - EventManager.Web,
the EventManager.Services project and the EventManager.Data project. The services project references the Data project
and the Web project references the previous two projects.





