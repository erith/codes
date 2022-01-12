
```powershell
# 만들기 #
dotnet new sln -n api
dotnet new tool-manifest
dotnet tool install NSwag.ConsoleCore --version 13.15.5
explorer .
dotnet nswag run nswag.json
```
