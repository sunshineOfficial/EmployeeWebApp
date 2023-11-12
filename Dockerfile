FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmployeeWebApp.Api/EmployeeWebApp.Api.csproj", "EmployeeWebApp.Api/"]
COPY ["EmployeeWebApp.Application/EmployeeWebApp.Application.csproj", "EmployeeWebApp.Application/"]
COPY ["EmployeeWebApp.Domain/EmployeeWebApp.Domain.csproj", "EmployeeWebApp.Domain/"]
COPY ["EmployeeWebApp.Infrastructure/EmployeeWebApp.Infrastructure.csproj", "EmployeeWebApp.Infrastructure/"]
RUN dotnet restore "EmployeeWebApp.Api/EmployeeWebApp.Api.csproj"
COPY . .
WORKDIR "/src/EmployeeWebApp.Api"
RUN dotnet build "EmployeeWebApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeWebApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeWebApp.Api.dll"]
