# TaskManager
# Usando Container
	## Criando Container Base de Dados
 		docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=[senhaforte]" -p 1433:1433 -d mcr.microsoft.com/mssql/server
	  
	## 
