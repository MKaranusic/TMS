FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TMS.API/TMS.API.csproj", "TMS.API/"]
COPY ["TMS.Core/TMS.Core.csproj", "TMS.Core/"]
COPY ["TMS.Data/TMS.Data.csproj", "TMS.Data/"]
RUN dotnet restore "TMS.API/TMS.API.csproj"
COPY . .
WORKDIR "/src/TMS.API"
RUN dotnet build "TMS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TMS.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080
ENV ConnectionStrings__TMSConnection="Server=db;Database=TMS;User Id=sa;Password=TaskDemo@123;TrustServerCertificate=True;"
ENV Cors__AllowedOrigins__0=http://localhost:3000

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TMS.API.dll"]
