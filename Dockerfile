FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY src/api/ ./
RUN dotnet restore
RUN dotnet build
RUN dotnet publish -c Release
ENTRYPOINT ["dotnet", "/app/bin/Release/netcoreapp2.0/api.dll"]