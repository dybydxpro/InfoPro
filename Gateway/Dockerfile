FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app/infopro/gateway
#EXPOSE 80
#EXPOSE 443

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -r linux-musl-x64 -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app/infopro/gateway
COPY --from=build-env /app/infopro/gateway/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "Gateway.dll"]