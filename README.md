<div align="center">
  <br>
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 9" />
  <img src="https://img.shields.io/badge/Blazor%20WASM-9.0-512BD4?style=for-the-badge&logo=blazor&logoColor=white" alt="Blazor WASM" />
  <img src="https://img.shields.io/badge/Docker-Compose-2496ED?style=for-the-badge&logo=docker&logoColor=white" alt="Docker Compose" />
  <img src="https://img.shields.io/badge/MediatR-14.1-FF2D20?style=for-the-badge" alt="MediatR" />
  <img src="https://img.shields.io/badge/EF%20Core%20SQLite-9.0-003B57?style=for-the-badge&logo=sqlite&logoColor=white" alt="EF Core SQLite" />
  <img src="https://img.shields.io/badge/license-MIT-green?style=for-the-badge" alt="MIT License" />
  <br><br>
</div>

# 🏚️ Silent Hill — Bestiário

> *"Na névoa, os monstros são apenas o começo..."*

Aplicação **Blazor WebAssembly** que consome uma **API REST** para exibir um bestiário interativo das criaturas da franquia *Silent Hill*. Dados persistidos em **SQLite** com **EF Core**, servidos via endpoints REST com arquitetura **Clean Architecture** + **CQRS** (MediatR).

---

## 📦 Estrutura do Projeto

```
SilentHillSolution/
├── SilentHill.API/              # API REST (ASP.NET Core 9)
│   ├── GET  /api/criaturas      # Lista todas
│   └── POST /api/criaturas      # Cria nova
├── SilentHill.Blazor/           # Frontend Blazor WebAssembly
│   └── Páginas: Home, Bestiário
├── SilentHill.Application/      # Casos de uso (CQRS / MediatR)
│   ├── Criaturas/Queries/       # Consultas
│   └── Criaturas/Commands/      # Comandos
├── SilentHill.Domain/           # Entidades do domínio (Criatura)
├── SilentHill.Infrastructure/   # Persistência (EF Core + SQLite)
│   ├── Persistence/             # AppDbContext + Seed
│   └── Repositories/            # Implementações
├── SilentHill.Shared/           # DTOs compartilhados (CriaturaDto)
├── SilentHill.Docker/           # Wrapper .NET para docker compose
├── docker-compose.yml           # Orquestração API + Blazor
└── SilentHill.sln               # Solução do Visual Studio
```

### 🧩 Tecnologias

| Camada     | Stack |
|------------|-------|
| Frontend   | Blazor WebAssembly (.NET 9) |
| Backend    | ASP.NET Core 9 + MediatR 14.1 |
| Banco      | SQLite via EF Core 9 |
| Persistência | Volume Docker `sqlite_data` |
| Padrão     | Clean Architecture + CQRS |
| Container  | Docker Compose (Nginx + ASP.NET) |
| Build      | .NET SDK 9.0 |
| Licença    | MIT |

---

## 🚀 Como Rodar

### 🔹 Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (recomendado)
- Git

### 🔹 Opção 1 — Docker Compose (recomendado)

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/SilentHillSolution.git
cd SilentHillSolution

# Sobe API + Blazor
docker compose up --build
```

Acesse:
- **Frontend:** http://localhost:5010
- **API:** http://localhost:5235/api/criaturas

### 🔹 Opção 2 — Rodar localmente (sem Docker)

```powershell
# Terminal 1 — API
dotnet run --project SilentHill.API --launch-profile http

# Terminal 2 — Blazor
dotnet run --project SilentHill.Blazor --launch-profile http
```

### 🔹 Opção 3 — Usando o wrapper .NET (com Docker)

```powershell
dotnet run --project SilentHill.Docker
```

---

## 🌐 Páginas

| Rota       | Descrição |
|------------|-----------|
| `/`        | Home — Apresentação com cards de funcionalidades |
| `/bestiario` | Bestiário — Lista de criaturas vindas da API |

### 🎨 Temas

Layout **dark mode** com temática Silent Hill:
- Efeito de névoa animado em CSS
- Paleta preta + vermelho sangue (`#8b0000`)
- Glassmorphism na navegação
- Tipografia: Creepster (títulos) + Inter (corpo)
- Ícones Font Awesome

---

## 📡 API

### `GET /api/criaturas`

Retorna todas as criaturas do bestiário.

```json
[
  {
    "id": 1,
    "nome": "Pyramid Head",
    "descricao": "O executor de Silent Hill 2...",
    "jogoOrigem": "Silent Hill 2",
    "imagemUrl": "https://...",
    "nivelPerigo": 5
  }
]
```

### `POST /api/criaturas`

Cria uma nova criatura.

```json
{
  "nome": "Lisa Garland",
  "descricao": "Uma enfermeira atormentada...",
  "jogoOrigem": "Silent Hill 1",
  "imagemUrl": "",
  "nivelPerigo": 2
}
```

**Resposta:** `201 Created` com a criatura criada (incluindo `id` gerado).

### Modelo

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `id` | int | Identificador único (auto-incremento) |
| `nome` | string | Nome da criatura |
| `descricao` | string | Descrição detalhada |
| `jogoOrigem` | string | Jogo de origem |
| `imagemUrl` | string | URL da imagem |
| `nivelPerigo` | int | Nível de perigo (1–5) |

**CORS:** Liberado para qualquer origem (`AllowAnyOrigin`).

---

## 🗄️ Banco de Dados

**SQLite** com **EF Core 9**. O banco é criado automaticamente na primeira execução via `EnsureCreated()`, com seed data de 2 criaturas (Pyramid Head e Bubble Head Nurse).

| Ambiente | Arquivo |
|----------|---------|
| Local (dev) | `SilentHill.API/silenthill.db` |
| Docker | Volume `sqlite_data` em `/data/silenthill.db` |

> Para resetar o banco, basta deletar o arquivo `silenthill.db` (local) ou o volume Docker (`docker compose down -v`).

---

## ⚙️ Configuração

### URL da API (Blazor)

`SilentHill.Blazor/wwwroot/appsettings.json`:

```json
{
  "ApiBaseUrl": "http://localhost:5235"
}
```

### Connection String (API)

`SilentHill.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultDb": "Data Source=silenthill.db"
  }
}
```

No Docker, a connection string é sobrescrita via variável de ambiente (`ConnectionStrings__DefaultDb`) para o caminho do volume.

---

## 📁 .dockerignore

O projeto inclui `.dockerignore` para excluir do build Docker:
- `bin/`, `obj/`, `.git/`, `.vs/`, `node_modules/`

---

## 📄 Licença

Este projeto está sob licença **MIT**. Sinta-se à vontade para usar, modificar e distribuir.

---

<p align="center">
  <sub>Feito com 🩸 para os fãs de Silent Hill</sub>
</p>
