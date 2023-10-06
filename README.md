 # ASP.NET Core WebApi - Rental App
<br/>

# Requirements
- Rental web app
- Entities:
  1. Rental pick-up locations
    - rent and return at any given location
    - price multiplier?
  2. Users
    - Reserve rental for any given date and location
    - Track reservation history, upcoming and active ones too
  3. Reservation
    - Date range and pick-up location
    - Details of the user making a reservation
    - Rented vehicle
    - Calculated price, formula: vehicle base fee x days rented
    - Cancellation fee?
    - Can't be booked retrospectively
    - Rentals can't overlap on the same vehicle
  4. Vehicles
    - All teslas (passenger only, no semi)
    - VIN as an alternate key
    - base fee

### API Capabilities

API is capable of all CRUD operations on Location, Vehicle, and Reservation models.
All entities are validated using Abstract Validator before any DB operations, besides that there is also business validation.

No business logic is hard-coded, the fees may be adjusted without altering previous reservations, locations and vehicles easily added.

Vehicles must have a unique VIN number, reservations can't overlap for a specific vehicle, etc. Most of these checks are available as an API method.

The authentication and authorization implementation is in place but it's not being used on any method due to how simple the front-end currently is.

### Database Structure
If the task was not in C# I'd probably use a JS API with NoSQL database behind it. Instead, I've used SQL Server with EntityFramework.

I've slightly adjusted the vehicle schema to contain car make as well if the app needs to handle other makes than Tesla.
The pick-up location is a part of the reservation to make sure the car will be in the requested rental location.
The return location should be set as a location in the vehicle at the end of the rental.
Fees are calculated upon rental and stored in the Reservations table.

![image](https://github.com/piotrokrutniak/RentalApp.Api/assets/91792866/8a747e0f-e145-4abc-84df-c13f72d7b656)

### Front-End

The API is supported by [Next.js web app](https://github.com/piotrokrutniak/RentalApp.WebUi/), in the current scope it's capable of searching vehicles by model, checking their  availability, and booking them.

### An Implementation of Clean Architecture with ASP.NET WebApi for a rental app.

1. Clone this Repository and Extract it to a Folder.
3. Change the Connection Strings for the Application and Identity in the WebApi/appsettings.json - (WebApi Project)
4. PMC project: InfrastructureShared
5. Startup project: WebApi
6. Run the following commands on Powershell in the WebApi Projecct's Directory
- dotnet restore
- dotnet ef database update -c ApplicationDbContext --project WebApi
- dotnet ef database update -c IdentityDbContext --project WebApi

Alternatively, you can switch the UseInMemoryDatabase flag in appsettings.json and use the in-memory database.

Swagger is available at ../swagger/index.html endpoint.

### Default Roles & Credentials
As soon you build and run your application, default users and roles get added to the database.

Default Roles are as follows.
- SuperAdmin
- Admin
- Moderator
- Basic

Here are the credentials for the default users.
- Email - superadmin@gmail.com  / Password - 123Pa$$word!
- Email - basic@gmail.com  / Password - 123Pa$$word!

You can use these default credentials to generate valid JWTokens at the ../api/account/authenticate endpoint.
