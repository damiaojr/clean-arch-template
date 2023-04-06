FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
RUN dotnet restore "src/API/OI.Template.API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "OI.Template.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OI.Template.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OI.Template.API.dll"]
