# InfoPro-production_flow_managemant_system-


# SQL Server
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Abc@1234" -e "MSSQL_PID=Evaluation" -p 1430:1433  --name infopro_db -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

# Identity
docker build -t dybydxpro/identity .
docker run -p 5002:80 --name infopro_identity -d dybydxpro/identity