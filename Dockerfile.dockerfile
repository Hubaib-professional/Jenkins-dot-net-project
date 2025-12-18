# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SampleJenkinsDeploy.csproj", "."]
RUN dotnet restore "SampleJenkinsDeploy.csproj"
COPY . .
RUN dotnet build "SampleJenkinsDeploy.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "SampleJenkinsDeploy.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleJenkinsDeploy.dll"]