FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/EmployeeWebApp.Api/EmployeeWebApp.Api.csproj", "EmployeeWebApp.Api/"]
RUN dotnet restore "EmployeeWebApp.Api/EmployeeWebApp.Api.csproj"
COPY . .
WORKDIR "/src/src/EmployeeWebApp.Api"
RUN dotnet build "EmployeeWebApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeWebApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeWebApp.Api.dll"]
