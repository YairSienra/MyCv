FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0 AS build
WORKDIR /source


EXPOSE 80
EXPOSE 5000
EXPOSE 5243
#Copy project files
COPY . .
RUN dotnet restore

#Copy everything else
COPY . .

RUN dotnet restore "./WebApi/WebApi.csproj" --disable-parallel
RUN dotnet publish "./WebApi/WebApi.csproj" -c release -o /app --no-restore

#Build Image
FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0 
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT [ "dotnet",  "WebApi.dll"]