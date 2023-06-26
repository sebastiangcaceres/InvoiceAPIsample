## Invoice CRUD API Sample

This project is an example of a REST API using ASP.NET Core 6.0 and Entity Framework Core with a code-first approach.

This project is a REST API in ASP.Net C# and uses the latest version of ASP.NET.

All CRUD operations such as Create, Read, Update and Delete are included, using REST patterns.

A SQL Server database and Entity Framework Core (EF Core) are used to perform the CRUD operations.

This project uses dependency injection for this API and follows SOLID principles for clean code.

CRUD:

+ Create/Add (POST)
+ Read/Get All and by Id (GET)
+ Update (PUT)
+ Delete (DELETE)


UPDATES (25/6/2023)
+ Invoice Lines, added a collection of lines to Invoice, model, DB (migrations), etc.
+ ConnectionStrings, the ConnectionStrings was moved from appsettings.json to appsettings.Development.json.
+ FluentValidation, added an Invoice Validator with rules and the logic in his controller to validate on POST and PUT.
+ Repository pattern, added the repository pattern in the DAL folder and the logic in his controller.
+ Swagger configuration, added configuration to swagger.
+ Integration test, added new test project with automated test cases: GetAllInvoices and InsertInvoices.
+ ActionResult, all CRUD metods return ActionResults now.