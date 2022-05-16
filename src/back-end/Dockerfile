FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdoptApi/AdoptApi.csproj", "AdoptApi/"]
RUN dotnet restore "AdoptApi/AdoptApi.csproj"
COPY . .
WORKDIR "/src/AdoptApi"
RUN dotnet build "AdoptApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdoptApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdoptApi.dll"]