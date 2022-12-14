FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExploreIdentityServer6/ExploreIdentityServer6.csproj", "ExploreIdentityServer6/"]
RUN dotnet restore "ExploreIdentityServer6/ExploreIdentityServer6.csproj"
COPY . .
WORKDIR "/src/ExploreIdentityServer6"
RUN dotnet build "ExploreIdentityServer6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExploreIdentityServer6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExploreIdentityServer6.dll"]
