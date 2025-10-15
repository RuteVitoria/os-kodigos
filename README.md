# Sistema de Ordem de Serviço

Este projeto é um sistema de Ordem de Serviço com **frontend em Angular (TypeScript)** e **backend em C# (.NET 7)**. O sistema permite que usuários façam login, criem contas e gerenciem ordens de serviço com rotas protegidas por autenticação JWT.

---

## Tecnologias Utilizadas

### Frontend
- Angular 16
- TypeScript
- Angular Material
- RxJS
- JWT para autenticação

### Backend
- .NET 7 (ASP.NET Core Web API)
- C#
- Entity Framework Core
- JWT para autenticação
- SQLite

---

## Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [Node.js](https://nodejs.org/) (v18+)
- [Angular CLI](https://angular.io/cli)
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [SQLite](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (ou outro banco)
- Git

---

## Passo a passo para rodar o projeto

1. Clonar o repositório

git clone https://github.com/SEU_USUARIO/sistema-os.git
cd os-base

2. Backend (.NET)

- Navegue até a pasta do backend:

cd OrdemServicoApi

- Restaurar pacotes NuGet:

dotnet restore

3. Criar banco de dados e rodar migrations (opcional):

dotnet ef database update

4. Executar a API:

dotnet run
OBS: A API estará disponível em http://localhost:5008.

5. Navegue até a pasta do frontend:

cd os-base

6. Instalar dependências:

npm install

7. Configurar URL da API no auth.service.ts:

private apiUrl = 'http://localhost:5008/api/Auth';

8. Executar a aplicação Angular:

ng serve
OBS: O frontend estará disponível em http://localhost:4200.

- Funcionalidades

Registro de usuário

Login com JWT

Criação de Ordem de Serviço

Logout

