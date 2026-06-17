<div align="center">
  <br>
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 9" />
  <img src="https://img.shields.io/badge/Blazor%20WASM-9.0-512BD4?style=for-the-badge&logo=blazor&logoColor=white" alt="Blazor WASM" />
  <img src="https://img.shields.io/badge/Docker-Compose-2496ED?style=for-the-badge&logo=docker&logoColor=white" alt="Docker Compose" />
  <img src="https://img.shields.io/badge/MediatR-14.1-FF2D20?style=for-the-badge" alt="MediatR" />
  <img src="https://img.shields.io/badge/license-MIT-green?style=for-the-badge" alt="MIT License" />
  <br><br>
</div>

# 🏚️ Silent Hill — Bestiário

> *"Na névoa, os monstros são apenas o começo..."*

Aplicação **Blazor WebAssembly** que consome uma **API REST** para exibir um bestiário interativo das criaturas da franquia *Silent Hill*. Dados servidos via `GET /api/criaturas` com arquitetura **Clean Architecture** e **MediatR** (CQRS).

---

## 📦 Estrutura do Projeto

```
SilentHillSolution/
├── SilentHill.API/            # API REST (ASP.NET Core 9)
│   └── GET /api/criaturas     # Endpoint principal
├── SilentHill.Blazor/         # Frontend Blazor WebAssembly
│   └── Páginas: Home, Bestiário
├── SilentHill.Application/    # Casos de uso (CQRS / MediatR)
├── SilentHill.Domain/         # Entidades do domínio
├── SilentHill.Infrastructure/ # Acesso a dados / repositórios
├── SilentHill.Shared/         # DTOs compartilhados (CriaturaDto)
├── SilentHill.Docker/         # Wrapper .NET para docker compose
├── docker-compose.yml         # Orquestração API + Blazor
└── SilentHill.sln             # Solução do Visual Studio
```

### 🧩 Tecnologias

| Camada     | Stack |
|------------|-------|
| Frontend   | Blazor WebAssembly (.NET 9) |
| Backend    | ASP.NET Core 9 + MediatR 14.1 |
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

**Resposta:**
```json
[
  {
    "id": 1,
    "nome": "Pyramid Head",
    "descricao": "Uma figura misteriosa usando um capacete metálico em forma de pirâmide...",
    "jogoOrigem": "Silent Hill 2",
    "imagemUrl": "https://exemplo.com/pyramid-head.jpg",
    "nivelPerigo": 5
  }
]
```

**Parâmetros da criatura:**

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `id` | int | Identificador único |
| `nome` | string | Nome da criatura |
| `descricao` | string | Descrição detalhada |
| `jogoOrigem` | string | Jogo de origem da criatura |
| `imagemUrl` | string | URL da imagem |
| `nivelPerigo` | int | Nível de perigo (1–5) |

**CORS:** Liberado para qualquer origem (`AllowAnyOrigin`).

---

## ⚙️ Configuração

### URL da API

No arquivo `SilentHill.Blazor/wwwroot/appsettings.json`:

```json
{
  "ApiBaseUrl": "http://localhost:5235"
}
```

> Para mudar o ambiente (ex: Docker), crie um `appsettings.Docker.json` ou altere o valor diretamente.

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
