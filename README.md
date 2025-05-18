# Personal Finance Tracker - Backend

## Overview
The Personal Finance Tracker backend is a RESTful API built with .NET 8, ASP.NET Core, and Entity Framework Core, using PostgreSQL as the database. It provides endpoints for user authentication (via ASP.NET Identity) and transaction management, secured with JWT-based authentication. The API integrates with an Angular 19 frontend (http://localhost:4200) and supports CORS for development.

## Features

* User Authentication: Register and log in users with email and password.
* Transaction Management: Create and retrieve transactions with fields for amount, description, date, category, type, and user ID.
* Database: PostgreSQL with migrations for schema management.
* Security: JWT tokens for authenticated requests.
* Logging: Serilog for console and file logging (logs/app.log).

## Prerequisites

* .NET SDK: 8.0
* PostgreSQL: v15 (brew install postgresql@15)
* Postico: For database management
* macOS: Tested on macOS
* Git: For cloning the repository

## Setup and Installation

1. ### Clone the Repository:
<pre>git clone https://github.com/<your-username>/personal-finance-tracker-backend.git
cd personal-finance-tracker-backend</pre>


2. ### Configure PostgreSQL:

* Start PostgreSQL:brew services start postgresql@15


* Create the database:
<pre>  -- In psql or Postico
CREATE DATABASE FinanceTrackerDb;</pre>


* Update appsettings.json with your connection string:
  <pre>
  {
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=FinanceTrackerDb;Username=postgres;Password=your-password"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
</pre>



3. ### Install Dependencies:
<pre>dotnet restore</pre>


4. ### Apply Migrations:
<pre>dotnet ef database update</pre>


* This creates the Transactions table with an auto-incrementing Id (GENERATED ALWAYS AS IDENTITY).


5. ### Verify Schema in Postico:

* Connect to FinanceTrackerDb.
* Run:
  <pre>\d "Transactions"</pre>


* Confirm Id is integer generated always as identity.



## Running the Application

1. ### Start the API:
<pre>dotnet run </pre>


* API listens on http://localhost:5117.


2. ### Ensure Frontend is Running:

* The frontend must be running at http://localhost:4200 for full functionality.


3. ### Test Endpoints:

* ### Register:
<pre>c
url -X POST http://localhost:5117/api/auth/register \
-H "Content-Type: application/json" \
-d '{"email":"zeus01@gmail.com","password":"Password123!"}'
</pre>


* ### Login:
<pre>
curl -X POST http://localhost:5117/api/auth/login \
-H "Content-Type: application/json" \
-d '{"email":"zeus01@gmail.com","password":"Password123!"}'
</pre>


* ### Create Transaction:
<pre>  
curl -X POST http://localhost:5117/api/transactions \
-H "Content-Type: application/json" \
-H "Authorization: Bearer <your-jwt-token>" \
-d '{"amount":50.75,"description":"Groceries","date":"2025-05-17","category":"Food","type":"Expense"}'
</pre>





## Testing

1. ### Unit Tests:

* Add tests in tests/PersonalFinanceTracker.Tests (create if needed):
<pre>
dotnet new xunit -o tests/PersonalFinanceTracker.Tests
</pre>

* Run tests:
  <pre>
  dotnet test
  </pre>




2. ### Manual Testing:

* Use Postman or curl to test endpoints.
* Verify transactions in Postico:
  <pre>
  SELECT * FROM "Transactions";
  </pre>




3. ### Logs:

* Check logs/app.log for errors or request details.



## Contributing

1. Fork the repository.
2. Create a feature branch (git checkout -b feature/your-feature).
3. Commit changes (git commit -m 'Add your feature').
4. Push to the branch (git push origin feature/your-feature).
5. Open a Pull Request.

## License
This project is licensed under the MIT License.

## Contact
For issues or questions, contact <your-email> or open an issue on GitHub.
