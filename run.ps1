#!/usr/bin/env pwsh
# Restore, build y run (Windows PowerShell)
dotnet restore
dotnet build --configuration Debug
dotnet run --project . --urls "http://localhost:5000"