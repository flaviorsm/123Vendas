# 123Vendas API

Esta API faz parte do sistema 123Vendas, voltada para o gerenciamento de vendas. A API permite a criação, consulta, atualização e exclusão de registros de vendas, 
além de fornecer suporte para a publicação de eventos de domínio relacionados a compras. 
O projeto utiliza DDD (Domain-Driven Design), arquitetura Onion, TDD (Test-Driven Development), e vários padrões de design.

## Tecnologias Utilizadas

- .NET Core: Plataforma utilizada para desenvolvimento da API.
- Entity Framework Core: Para manipulação de banco de dados utilizando Code First.
- Serilog: Para registro e monitoramento de logs.- 
- Swagger: Documentação interativa da API.
- DDD: Aplicação dos princípios de Domain-Driven Design para separação dos domínios e agregados.
- TDD: Testes unitários e de integração foram implementados seguindo a abordagem de desenvolvimento orientado a testes.

## Funcionalidades

- CRUD de Vendas: Permite a criação, consulta, atualização e exclusão de registros de vendas.
- Eventos de Domínio: Simulação de eventos como CompraCriada, CompraAlterada, CompraCancelada, e ItemCancelado.
- Logs: Todos os eventos críticos são registrados no console e em arquivos de log usando Serilog.

## Como Executar

1. Clone o Repositório:
```
git clone https://github.com/seu-usuario/123vendas-api.git

```
2. Configure a aplicação:
- Certifique-se de ter o .NET SDK instalado.
- Edite o arquivo appsettings.json para configurar a conexão com o banco de dados.

3. Execute as Migrações:
```
dotnet ef database update

```
4. Execute a Aplicação:
```
dotnet run

```
5. Acesse a documentação da API via Swagger:
```
https://localhost:5001/swagger/index.html

```
## Estrutura do Projeto

- Dominio: Contém as entidades, agregados e interfaces dos repositórios.
- Aplicação: Implementa os serviços, DTOs, e lógica de aplicação.
- Infraestrutura: Implementa o repositório utilizando o Entity Framework.
- API: Contém os controllers da API.

## Testes

Os testes de unidade e de integração foram implementados para os serviços e repositórios da aplicação. Para executar os testes:

```
dotnet test

```

## Migrations (Migrações Code First)

Para criar e aplicar migrações no EF Core, use os seguintes comandos no terminal:

1. Criar a migração inicial:

```
dotnet ef migrations add InitialCreate

```
2. Aplicar as migrações no banco de dados:

```
dotnet ef database update

```
	