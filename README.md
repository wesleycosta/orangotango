# to-de-ferias-bookings
Microsserviço responsável pelo gerenciamento de reservas e hóspedes.

[![CodeFactor](https://www.codefactor.io/repository/github/wesleycosta/to-de-ferias-bookings/badge)](https://www.codefactor.io/repository/github/wesleycosta/to-de-ferias-bookings)
[![Build Status](https://wlcosta.visualstudio.com/ToDeFeriasBooking/_apis/build/status/to-de-ferias-booking-ci?branchName=main)](https://wlcosta.visualstudio.com/ToDeFeriasBooking/_build/latest?definitionId=7&branchName=main)

## Arquitetura
Arquitetura construida com preocupações de separação de responsabilidades, seguindo as boas práticas de SOLID e Clean Code.

- Hexagonal Architecture
- Domain Driven Design
- Domain Events
- Domain Notification
- Domain Validations
- CQRS
- Retry Pattern
- Unit of Work
- Repository

<p align="center">
  <img src="./docs/architecture.png" />
</p>

- **SPA**: Front-end em Angular;
- **API Gateway**: API gateway com Ocelot;
- **Bookings**: Microsserviço responsável pelo gerenciamento de reservas e hóspedes;
- **Rooms**: Microsserviço responsável pelo gerenciamento de quartos e categorias;
- **Notifications**: Microsserviço responsável pelo envio de notificações.

## Componentes
- AutoFixture
- AutoMapper
- ELK
- EntityFramework
- FluentValidation
- MediatR
- Moq
- NetDevPack.Brasil
- Serilog
- Swagger
- XUnit

## Diagrama de classes
<p align="center">
  <img src="./docs/class-diagram.png" />
</p>

## Estrutura do projeto
<p>
  <img src="./docs/solution.png" />
</p>

## Documentação da API
<p align="center">
  <img src="./docs/api-docs.png" />
</p>