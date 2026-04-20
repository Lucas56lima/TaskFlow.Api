TaskFlow
├── TaskFlow.Api           → Camada de apresentação (controllers)
├── TaskFlow.Application   → Regras de negócio, DTOs, services
├── TaskFlow.Domain        → Entidades e enums
├── TaskFlow.Infrastructure→ Acesso a dados (EF Core)

Tecnologias utilizadas
.NET 8
Entity Framework Core
SQL Server
Docker (opcional)
Result Pattern (tratamento de erros)
FluentValidation (validação de entrada)

1. Clonar o repositório
git clone [https://seu-repo-aqui.git](https://github.com/Lucas56lima/TaskFlow.Api.git
cd TaskFlow

Configuração do banco de dados

Você pode rodar de duas formas:

Opção 1 — Local (sem Docker)
Configure o appsettings.json
"ConnectionStrings": {
  "Default": "Server=(localdb)\\MSSQLLocalDB;Database=TaskFlowDb;Trusted_Connection=True;"
}
Criar as migrations
dotnet ef migrations add InitialCreate \
--project TaskFlow.Infrastructure \
--startup-project TaskFlow.Api

Aplicar no banco
dotnet ef database update \
--project TaskFlow.Infrastructure \
--startup-project TaskFlow.Api

Opção 2 — Usando Docker
Criar arquivo .env
SA_PASSWORD=SuaSenhaForte123!
CONNECTION_STRING=Server=sqlserver,1433;Database=TaskFlowDb;User Id=sa;Password=SuaSenhaForte123!;Trust
Há um exemplo no repositório.

