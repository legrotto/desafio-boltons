## Desafio Boltons

# O que é o projeto?
O projeto desenvolvido em ASP Net Core, faz integração com a API https://sandbox-api.arquivei.com.br/v1/nfe/received.
Após a integração, os dados retornados dessa API são inseridos em um banco de dados relacional, nesse caso o banco utilizado foi o MySql
Sendo possível consultar os itens da integração, a partir de uma chave de acesso.

## Como usar:
1. Clone ou faça o download do projeto para a sua máquina

2. Utilize a chave default de conexão ou crie uma própia, para isso:
    2.1. Instale o configure o [MySql](https://dev.mysql.com/downloads/mysql/)
    2.2. Se necessário, informe a string de conexão no projeto DesafioBoltons.Infra.Data/Context/MySqlContext.cs
    * Altere o nome do servidor, tag [SERVER]
    * Altere a porta do servidor, tag [PORT] 
    * Altere o usuário do banco de dados, tag [USER]
    * Altere a senha do usuário do banco de dados, tag [PASSWORD] tag
	2.3. Se necessário, também altere os dados na conexão no arquivo DesafioBoltons.Application/appsettings.json
	
3. Finalmente, builde e execute o projeto

## MySql Migrations:
1. Abra seu Package Manager Console
2. Mude o projeto padrão para DesafioBoltons.Infra.Data
3. Execute o comando "Add-Migration [NOME DA SUA MIGRAÇÃO]"
4. Execute o comando "Update-Database"

## Tecnologias Implementadas:
* ASP.NET Core 3.1 (com .NET Core 3.1)
* Entity Framework Core
* FluentValidation
* Swagger UI 
* MySql Database Connection

## Sobre:
Projeto desenvolvido por [Letícia Grotto](https://www.linkedin.com/in/leticia-grotto/).
