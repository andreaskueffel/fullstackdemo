# Demo Project with C# / Angular

This demo project should show an entrypoint with a simple C# Backend service and an Angular based Frontend. 

The approach tries to automate the interface syncing between Backend API and Frontend Client by introducing this build steps:

- Build and run backend to generate openapi description (Swagger)
- Run openapi-generator-cli to generate TypeScript clients for Frontend
- Build Frontend and copy to Backend wwwroot folder
- Run the backend as Fullstack Application serving API and Frontend

## Prerequisites
To run the WebKeyGen build script (build_webkeygen.cmd) on Windows, the following tools must be installed and available in your system PATH:
1. .NET SDK 8.0 or newer
Required to execute the following command that generates the OpenAPI specification:
```
dotnet run --project MachineLicenseManagement.WebKeyGen --export-openapi
```
2. Node.js (LTS) + npm + Angular CLI
Used to install and build the Angular frontend:
```
npm install
npm run generate
ng build --configuration production
```