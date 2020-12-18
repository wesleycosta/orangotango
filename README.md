<img src="https://github.com/wesleycosta/orangotango/blob/master/docs/design/oragotango_with_title.PNG" />

Sistema distribuído com uma arquitetura hexagonal para monitoramento de logs.

## Subindo o Ambiente de DEV
### 1 - Rodando o Back-End
Para criar rapidamente o ambiente disponibilizamos as imagens Docker dos 2 recursos da aplicação:

- [PostgreSQL]
- [RabbitMQ]

> **Requisito:** É necessário ter o docker instalado em seu sistema operacional

#### Subindo o docker compose
* Acesse o diretório: `\development`
* Abre o arquivo: `docker-compose-dev.yml up -d` 
* Altere o diretório do volume da pasta data do postgres, para um caminho existente no seu computador: <br>
` volumes:`<br>
      `- C:/Outros/postgres/data:/var/lib/postgresql/data`
* Rode o comando: `docker-compose -f docker-compose-dev.yml up -d` 

##### Para parar a execução no console (executando no modo 'detached'):  
- ` docker-compose down` 

##### Para parar a execução no console (executando no modo 'attached'):  
- <kbd>Crtl</kbd> + <kbd>C</kbd>

### 2 - Rodando o Web App
* Acesse o diretório: `\src\frontend`
* Se for a primeira vez que irá executar o Web App, será necessário instalar os pacotes do angular, então rode o comando: `npm install` 
* Rode o seguinte comando para iniciar a aplicação na porta 4200: `ng s`
> **Requisito:** É necessário ter o Node.js e o npm instalado em seu sistema operacional
