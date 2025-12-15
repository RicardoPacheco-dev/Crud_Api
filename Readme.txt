packages needed

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0 
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package AutoMapper --version 13.0.1
dotnet tool install --global dotnet-ef

And SqlServer Manager 2025

//Create the initial migrations in case the ones on the proyect do not function
dotnet ef migrations add InitialCreate

//Automatic actualizer of the database
dotnet ef database update
