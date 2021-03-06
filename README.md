<p align="center">
  <img  height="256" src="./docs/design/oragotango_with_title.PNG" />
</p>
<p  align="center">Sistema distribuído com uma arquitetura hexagonal para gerenciamento de reservas de hotéis e pousadas.</p>

## Arquitetura

Arquitetura construida com preocupações de separação de responsabilidades, seguindo as boas práticas de SOLID e Clean Code.
* Domain Driven Design;
* Domain Events;
* Domain Notification;
* Domain Validations;
* CQRS;
* Event Sourcing;
* Unit of Work;
* Message Bus;
* Repository.

## Diagrama de classes
<p align="center">
  <img src="./docs/diagram/class_diagram.png" />
</p>

## Tecnologias utlizadas
* .NET 5.0;
* ASP.NET WebApi;
* AutoMapper; 
* FluentValidator;
* JWT;
* MediatR;
* MongoDB;
* Moq;
* NetDevPackBr;
* NUnit;
* Polly;
* SignalR;
* Swagger;
* Xunit;
* Angular 11;
* Angular Material.

## Ambiente de DEV
#### Rodando o Back-End
Disponibilizamos imagens docker para criar os recursos da aplicação:

- [MongoDB]
- [RabbitMQ]


> **Requisito:** É necessário ter o docker instalado em seu sistema operacional

#### Subindo o docker compose
* Acesse o diretório: `\development`
* Rode o comando: `docker-compose -f docker-compose-dev.yml up -d` 

#### Rodando o Web App
* Acesse o diretório: `\src\webapp`
* Se for a primeira vez que irá executar o Web App, será necessário instalar as dependências, então rode o comando: `npm install` 
* Rode o seguinte comando para iniciar a aplicação na porta 4200: `ng s`
> **Requisito:** É necessário ter o Node.js, Angular CLI e o npm instalado em seu sistema operacional.
