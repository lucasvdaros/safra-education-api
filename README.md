# What is Safra Education?
It's an open source project, written in .NET Core, currently in version 3.1.

The project's goals is to complete the Safra Bank Hackaton lol

## Business proposal:
The principle idea is to provide some servers that helps the users to learn about investments in a pratical scenario.

## How to use:
1. Clone this project to into your machine
2. Use the default connection string or:
    2.1. Install and configure [MySql](https://dev.mysql.com/downloads/mysql/).
    2.2. Inform the connection string on SafraEducation.Application/appsettings.json.
    * Put the server name on [SERVER] tag
    * Put the port number on [PORT] tag
    * Put the user name database on [USER] tag
    * Put the password database on [PASSWORD] tag
4. Finally, build and run the application

## Technologies implemented:
* ASP.NET Core 3.1 (with .NET Core 3.1)
* Entity Framework Core 3.1.5
* FluentValidation 9.0.0
* Swagger UI 5.5.0
* MySql Database Connection
* .NET Core Native DI

## Architecture:
* Layer architecture
* S.O.L.I.D. principles
* Clean Code
* Domain Validations
* Domain Notifications
* Domain Driven Design
* Repository Pattern
* Notification Pattern
* Mapper by Extension Methods
