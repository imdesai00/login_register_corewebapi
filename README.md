
# ASP.NET Core Web API: Login & Register with JWT Token Functionality
  This project is a demonstration of implementing user authentication and authorization in an ASP.NET Core Web API using JSON Web Tokens (JWT). It provides endpoints for user registration, user login, and accessing protected resources by validating JWT tokens.
## Features

- User Registration: Allows new users to create an account by providing necessary details such as username, email, and password.
- User Login: Provides an endpoint for existing users to authenticate themselves by providing their credentials (username/email and password).
- JWT Token Generation: Upon successful authentication, the server generates a JWT token containing user information and returns it to the client.
- JWT Token Validation: Protected endpoints require clients to include a valid JWT token in the Authorization header. The server validates the token to ensure the user has the necessary permissions to access the requested resource.
## Technologies Used

**ASP.NET Core:** The primary framework for building web applications and APIs.

**C#:** The programming language used for backend logic and API.

**JWT (JSON Web Tokens):** Used for secure token generation and authentication.

**Swagger UI:** A tool to document and test APIs.

**PostgreSQL:** A lightweight, file-based database used for local development and testing.


## Getting Started
To get started with this project, follow these steps:

1. Clone the Repository: Use git clone to clone this repository to your local machine.
2. Configure the necessary settings such as SMTP server details, email templates, and database connection string.Build and run the application.
3. Navigate to the Project Directory: cd into the directory containing the cloned repository.
4. Build and Run the Project: Use dotnet build to build the project, followed by dotnet run to start the development server.
5. Explore the API: Once the project is running, navigate to https://localhost:5001/swagger/index.html to explore and interact with the API using Swagger UI.
6. Test the Forgot Password and Reset Password endpoints using tools like Postman or through your application's frontend.
## Run Locally

Clone the project
```bash
  git clone https://github.com/imdesai00/login_register_corewebapi.git
```

Navigate to the project directory.
```bash
  cd your-repo
```

Set up the necessary database configurations in appsettings.json. 
```bash
  dotnet build
  dotnet run
```
## EndPoints
- POST /api/auth/register: Register a new user.
- POST /api/auth/login: Authenticate and receive a JWT token.