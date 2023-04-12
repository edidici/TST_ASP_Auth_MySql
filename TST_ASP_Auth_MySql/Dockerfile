#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TST_ASP_Auth_MySql/TST_ASP_Auth_MySql.csproj", "TST_ASP_Auth_MySql/"]
RUN dotnet restore "TST_ASP_Auth_MySql/TST_ASP_Auth_MySql.csproj"
COPY . .
WORKDIR "/src/TST_ASP_Auth_MySql"
RUN dotnet build "TST_ASP_Auth_MySql.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TST_ASP_Auth_MySql.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TST_ASP_Auth_MySql.dll"]