#!/bin/bash
set -e

# Clean
dotnet clean
rm -rf release

# Restore
dotnet restore

# Test
cd xunit.spec.automapper.tests
dotnet xunit
cd ..

# Package
dotnet pack -c Release -o ../artifacts xunit.spec.automapper/xunit.spec.automapper.csproj