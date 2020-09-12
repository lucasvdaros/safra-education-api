FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY *.sln .
COPY src/SafraEducation.Application/*.csproj ./src/SafraEducation.Application/
COPY src/SafraEducation.Domain/*.csproj ./src/SafraEducation.Domain/
COPY src/SafraEducation.Infra.CrossCutting/*.csproj ./src/SafraEducation.Infra.CrossCutting/
COPY src/SafraEducation.Infra.Data/*.csproj ./src/SafraEducation.Infra.Data/
COPY src/SafraEducation.Service/*.csproj ./src/SafraEducation.Service/
COPY test/SafraEducation.Test.Integration/*.csproj ./test/SafraEducation.Test.Integration/
COPY test/SafraEducation.Test.Unit/*.csproj ./test/SafraEducation.Test.Unit/
RUN dotnet restore
COPY src/. ./src/
WORKDIR /app
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "SafraEducation.Application.dll"]