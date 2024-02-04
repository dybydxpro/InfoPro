# InfoPro-production_flow_managemant_system-

## Docker
docker network create --subnet=172.24.1.0/24 infopro_net

## SQL Server
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Abc@1234" -e "MSSQL_PID=Evaluation" -p 1430:1433 --network infopro_net --ip 172.24.1.20 --name infopro_db -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

## Gateway
docker build -t dybydxpro/gateway .
docker run -p 5001:8080 --network infopro_net --ip 172.24.1.21 --name infopro_gateway -d dybydxpro/gateway

## Identity
docker build -t dybydxpro/identity .
docker run -p 5002:8080 --network infopro_net --ip 172.24.1.22 --name infopro_identity -d dybydxpro/identity