# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /source
COPY . .
RUN dotnet restore "TaskManager.Api/TaskManager.Api.csproj"
RUN dotnet publish "TaskManager.Api/TaskManager.Api.csproj" -c release -o /app --no-restore

# Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:5048;https://+:7220
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5048 7220

ENTRYPOINT ["dotnet", "TaskManager.Api.dll"]