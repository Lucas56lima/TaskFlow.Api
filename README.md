
---

## ⚙️ Tecnologias utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Docker (opcional)
- Result Pattern

---

## 🧪 Como rodar o projeto

### 🔹 1. Clonar o repositório

```bash
git clone https://github.com/Lucas56lima/TaskFlow.Api.git
cd TaskFlow

🗄️ Configuração do banco de dados

Você pode rodar o projeto de duas formas:

🟢 Opção 1 — Rodando localmente (sem Docker)
✔️ Configure o appsettings.json
"ConnectionStrings": {
  "Default": "Server=(localdb)\\MSSQLLocalDB;Database=TaskFlowDb;Trusted_Connection=True;"
}
✔️ Criar as migrations
dotnet ef migrations add InitialCreate --project TaskFlow.Infrastructure --startup-project TaskFlow.Api

✔️ Aplicar no banco
dotnet ef database update --project TaskFlow.Infrastructure --startup-project TaskFlow.Api

🐳 Opção 2 — Usando Docker
✔️ Criar arquivo .env
SA_PASSWORD=SuaSenhaForte123!
CONNECTION_STRING=Server=sqlserver,1433;Database=TaskFlowDb;User Id=sa;Password=SuaSenhaForte123!;TrustServerCertificate=True

👉 Existe um .env.example no repositório como referência.

✔️ Subir os containers
docker-compose up -d
✔️ Aplicar migrations
dotnet ef database update --project TaskFlow.Infrastructure --startup-project TaskFlow.Api


