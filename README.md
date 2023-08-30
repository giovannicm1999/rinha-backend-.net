# Projeto base em .Net para a rinha de backend promovida pela Muralis.
Projeto base feito em .net core utilizando Entity Framework Core, Docker e PostgresSQL, abaixo algumas informações que podem vir a ser úteis.

## Pré requisitos.
  - Visual Studio (utilizei a versão 2022);
  - Docker;
  - .Net core 7.0.

## Setup do Projeto

### 1. Clone o Repositório

```bash
git clone https://github.com/seu-usuario/seu-projeto.git
cd seu-projeto
```

### 2. Iniciar o PostgreSQL com Docker Compose

```bash
docker-compose up -d
```

Isso iniciará o PostgreSQL como definido no arquivo `docker-compose.yml`.

### 3. Buildar aplicação

```bash
dotnet build <PATH>/<TO>/<SLN_FILE>.sln
```

### 4. Rodar migration

```bash
dotnet ef migrations add {nome_migration}
```
É necessário estar dentro da pasta do projeto

### 4. Executar aplicação

```bash
dotnet {sua_aplicacao}.dll
```
A dll geralmente se encontra dentro da pasta /bin do seu projeto

## Endpoints

### Criação de Pessoas (POST /pessoas)

Envie um JSON com os dados da pessoa.

Exemplo:

```bash
curl --request POST \
  --url http://localhost:3000/pessoas \
  --header 'Content-Type: application/json' \
  --data '{
	"apelido": "ana",
	"nome": "Ana Barbosa",
	"nascimento": "1985-09-23",
	"stack": ["Node", "Postgres"]
}'
```

### Consulta por ID (GET /pessoas/:id)

Para buscar um recurso por ID.

```bash
curl http://localhost:3000/pessoas/5ce4668c-4710-4cfb-ae5f-38988d6d49cb
```

### Busca por Termo (GET /pessoas?t=:termo)

Para fazer uma busca em todos os campos.

```bash
curl http://localhost:3000/pessoas?t=ana
```

### Contagem de Pessoas (GET /contagem-pessoas)

Para obter o número total de pessoas cadastradas.

```bash
curl http://localhost:3000/contagem-pessoas
```

## Links úteis
- Monitoramento de CPU com Visual Studio: https://learn.microsoft.com/en-us/visualstudio/profiling/beginners-guide-to-performance-profiling?view=vs-2022
- Monitoramento de RAM com Visual Studio: https://learn.microsoft.com/en-us/visualstudio/profiling/memory-usage?view=vs-2022
