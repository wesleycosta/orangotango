<img src="https://github.com/wesleycosta/orangotango/blob/master/docs/design/oragotango_with_title.PNG" />

Sistema distribuído com uma arquitetura hexagonal para monitoramento de logs.

## Rodando o Back-End
Para criar rapidamente o ambiente disponibilizamos as imagens Docker dos 2 recursos da aplicação:

- [PostgreSQL]
- [RabbitMQ]

> **Requisito:** É necessário ter o docker instalado em seu sistema operacional (Linux, Windows ou Mac)

### Subindo o docker compose do back-end
* Acesse o diretório: `\development\orangotango`
* Altere o diretório do volume da pasta data do postgres, para um caminho existente no seu computador: <br>
` volumes:`<br>
      `- C:/Outros/postgres/data:/var/lib/postgresql/data`
* Rode o comando: ` docker-compose up` 

#### Para parar a execução no console (executando no modo 'detached'):  
- ` docker-compose down` 

#### Para parar a execução no console (executando no modo 'attached'):  
- <kbd>Crtl</kbd> + <kbd>C</kbd>
