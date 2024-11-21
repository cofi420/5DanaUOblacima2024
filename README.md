# 5 Dana u oblacima 2024

First round project that calculates elo for esports players.
By Filip Vidakovic
filip.vidaokovic.04@gmail.com
---

## Prerequisites

Ensure you have the following installed on your system:

1. **.NET SDK**: Version 8.0 or later  
   Download from [Microsoft .NET Download Page](https://dotnet.microsoft.com/download).
2. **IDE/Text Editor**: Visual Studio, Visual Studio Code, or any other editor supporting .NET Core development.
3. **Postman or Browser**: To interact with the APIs (optional).

---

## Building the Project

Follow these steps to build and run the application locally:

### 1. Clone the Repository
```bash
git clone https://github.com/cofi420/5DanaUOblacima2024.git
cd 5DanaUOblacima2024/
```
### 2. Restore dependencies
Use the following command to restore NuGet packages:
dotnet restore

### 3. Build the application
Build the project to ensure everything compiles correctly:
```
dotnet build
```

## Running the Application
The project includes multiple profiles defined in the launchSettings.json file. You can run the application in different configurations.

### 1. Using HTTPS Profile
To run the application with HTTPS, execute:
```
dotnet run --launch-profile https
```

Application URL: https://localhost:443 or http://localhost:8080
Swagger UI: https://localhost:443/swagger
### 2. Using HTTP Profile
To run the application without HTTPS, execute:
**!IMPORTANT: Run this one for correct port and http protocol for postman tests**

```
dotnet run --launch-profile http
```
Application URL: http://localhost:8080
Swagger UI: http://localhost:8080/swagger
### 3. Using IIS Express (Visual Studio Only)
If you're using Visual Studio, you can select the IIS Express profile from the debug dropdown and run the application directly.

## Testing API Endpoints
The API exposes its Swagger UI for easier testing and documentation.

After starting the application, navigate to the launchUrl defined in the selected profile. For example:

http://localhost:8080/swagger
https://localhost:443/swagger
Use the Swagger UI to explore and test the endpoints.

### Customizing Environment
The ASPNETCORE_ENVIRONMENT variable in launchSettings.json is set to Development by default. You can change it to other environments (e.g., Production) if required.

### Troubleshooting
# 1. Port Conflicts:

Ensure the ports defined in applicationUrl are not already in use.
Change the ports in launchSettings.json if needed.
### 2. SSL Certificate Issues:

Trust the development certificate by running:
```
dotnet dev-certs https --trust
```

### 3.Missing Dependencies:

Run dotnet restore to fetch any missing dependencies.
