# Cadastro de Pessoas

O projeto foi desenvolvido utilizando as seguintes tecnologias:
- **.Net 5**
- **Angular 11**
- **MariaDB**
- **Docker**

# Como executar
Após clonar o repositório, você poderá executar o projeto através destes dois métodos:

## Utilizando o docker-compose
- Execute o comando `docker-compose up -d` na pasta raiz da solução
- Acesse `http://localhost:4200` pelo navegador de sua preferência

## Utilizando Visual Studio / VS Code

### Executando a API
- Abra o arquivo de solução "API.sln" que se encontra dentro da pasta "API" utilizando o Visual Studio
- Pressione F5 ou vá em Depurar -> Iniciar Depuração
- Um navegador será iniciado já na página inicial do Swagger

### Executando a UI
- Abra a pasta "UI" no VS Code
- Pressione `` Ctrl+Shift+` ``
- Na nova janela do terminal execute os comandos:
- `npm i` e `ng serve`
- Acesse `http://localhost:4200` pelo navegador de sua preferência

Em ambos os casos, após iniciar o projeto, o mesmo executará as migrações e criará o BD.