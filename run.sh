#!/usr/bin/env bash
set -e
# Restore, build y run (Linux/macOS)
dotnet restore
dotnet build --configuration Debug
dotnet run --project . --urls "http://localhost:5000"