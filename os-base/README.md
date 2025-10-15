# os-prototipo

Protótipo de Ordem de Serviço (Frontend Angular + Backend .NET 8)
Tema frontend: rosinha minimalista
Backend: .NET 8 (em memória, sem banco)

## Como rodar

### Backend (.NET 8)cd
1. Abra o terminal em `backend/`
2. `dotnet restore`
3. `dotnet run --project backend`  # API rodará por padrão em https://localhost:7236 ou http://localhost:5236

### Frontend (Angular)
1. Abra o terminal em `frontend/`
2. `npm install`
3. `npm start` ou `npx ng serve --open`
4. Acesse http://localhost:4200

### Credenciais para teste
- email: user@example.com
- password: senha123

Observações:
- Upload de foto é enviado como FormData para `/api/orders`.
- Backend mantém ordens em memória durante a execução (simulação).
- JWT simples é retornado no login para proteger rota `/api/orders`.
