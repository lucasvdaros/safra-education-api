# What is Safra Education?
It's an open source project, written in .NET Core, currently in version 3.1.
The project's goals is to complete the Safra Bank Hackaton lol
## Business proposal:
The principle idea is to provide some servers that helps the users to learn about investments in a pratical scenario.

## How to use:
### Requisits
* Docker installed (click [here](https://docs.docker.com/get-docker/) to see how to install)
* Docker compose (click [here](https://docs.docker.com/compose/install/) to see how to install)
### How to run
1. Clone this project into your machine
2. Run `docker-compose up -d`
3. Go to `http://localhost:5000` to access the application
4. Run `docker-compose down --rmi all` to stop the application and erase the generated images

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