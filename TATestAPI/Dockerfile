#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
FROM mcr.microsoft.com/dotnet/core/runtime:2.1-nanoserver-sac2016
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TATestAPI.dll"]