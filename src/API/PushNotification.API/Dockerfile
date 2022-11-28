FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/API/PushNotification.API/PushNotification.API.csproj", "PushNotification.API/"]
RUN dotnet restore "src/API/PushNotification.API/PushNotification.API.csproj"
COPY . .
WORKDIR "/src/PushNotification.API"
RUN dotnet build "PushNotification.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PushNotification.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PushNotification.API.dll"]
