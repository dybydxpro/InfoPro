FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Identity.dll"]