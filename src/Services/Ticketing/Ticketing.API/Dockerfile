#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Ticketing/Ticketing.API/Ticketing.API.csproj", "src/Services/Ticketing/Ticketing.API/"]
RUN dotnet restore "src/Services/Ticketing/Ticketing.API/Ticketing.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Ticketing/Ticketing.API"
RUN dotnet build "Ticketing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ticketing.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ticketing.API.dll"]