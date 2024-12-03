FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /CineApi

COPY CineApi.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /CineApi
EXPOSE 7141

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CineApi.dll"]