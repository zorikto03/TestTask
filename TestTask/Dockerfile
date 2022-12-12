#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestTask/TestTask.csproj", "TestTask/"]
RUN dotnet restore "TestTask/TestTask.csproj"
COPY . .
WORKDIR "/src/TestTask"
RUN dotnet build "TestTask.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS migration
WORKDIR /src
COPY . .
RUN dotnet restore "TestTask.Migration/TestTask.Migration.csproj"
COPY . .
WORKDIR "/src/TestTask.Migration"
RUN dotnet build "TestTask.Migration.csproj" -c Release -o /app/migration

FROM build AS publish
RUN dotnet publish "TestTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTask.dll"]