<img  height="256" src="https://github.com/wesleycosta/orangotango/blob/master/docs/design/oragotango_with_title.PNG" />

Sistema para gerenciamento de reservas de hotéis e pousadas.

## Ambiente de DEV
#### Rodando o Back-End
Para criar rapidamente o ambiente disponibilizamos magens Docker dos recursos da aplicação:

- [MongoDB]
- [Redis]
- [RabbitMQ]

> **Requisito:** É necessário ter o docker instalado em seu sistema operacional

#### Subindo o docker compose
* Acesse o diretório: `\development`
* Rode o comando: `docker-compose -f docker-compose-dev.yml up -d` 

##### Para parar a execução no console (executando no modo 'detached'):  
- ` docker-compose down` 

##### Para parar a execução no console (executando no modo 'attached'):  
- <kbd>Crtl</kbd> + <kbd>C</kbd>

#### Rodando o Web App
* Acesse o diretório: `\src\webapp`
* Se for a primeira vez que irá executar o Web App, será necessário instalar as dependências, então rode o comando: `npm install` 
* Rode o seguinte comando para iniciar a aplicação na porta 4200: `ng s`
> **Requisito:** É necessário ter o Node.js, Angular CLI e o npm instalado em seu sistema operacional

## Modelagem de dados

<img src="https://raw.githubusercontent.com/wesleycosta/orangotango/master/docs/class%20diagram/diagram_updated.png" />

## Tecnologias utlizadas
* .NET Core 5.0;
* ASP.NET WebApi;
* AutoMapper; 
* FluentValidator;
* JWT;
* MediatR;
* MongoDB Driver (MongoDB.Bson e MongoDB.Driver);
* Moq;
* NetDevPackBr;
* NUnit;
* SignalR;
* Swagger;
* Xunit;
* Angular 11;
* Angular Material;
* Gridster2.

## Arquitetura

Arquitetura construida com preocupações de separação de responsabilidades, seguindo as boas práticas de SOLID e Clean Code.
* Domain Driven Design;
* Domain Events;
* Domain Notification;
* Domain Validations;
* CQRS;
* Event Sourcing;
* Unit of Work;
* Repository.
