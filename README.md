![Logo](https://github.com/wesleycosta/orangotango/raw/main/images/logos/logo_full.png)

**Orangotango** is a hotel reservation system that utilizes a modern and scalable microservices architecture.

## Projects

Orangotango is composed of six main projects, each playing a specific role in the system's architecture:

- [**orangotango-app**](https://github.com/wesleycosta/orangotango-app): A Single Page Application (SPA) built with Angular that communicates with the **orangotango-api-gateway**.[![Docker Hub](https://img.shields.io/badge/docker-hub-black.svg)](https://hub.docker.com/repository/docker/wesleycosta/orangotango-app)
- [**orangotango-api-gateway**](https://github.com/wesleycosta/orangotango-api-gateway): API Gateway using Ocelot to centralize requests for rooms and reservations microservices into a single entry point. [![Docker Hub](https://img.shields.io/badge/docker-hub-black.svg)](https://hub.docker.com/repository/docker/wesleycosta/orangotango-api-gateway)
- [**orangotango-rooms**](https://github.com/wesleycosta/orangotango-rooms): A microservice responsible for providing information about the available rooms at the hotel. [![Docker Hub](https://img.shields.io/badge/docker-hub-black.svg)](https://hub.docker.com/repository/docker/wesleycosta/orangotango-rooms)
- [**orangotango-reservations**](https://github.com/wesleycosta/orangotango-reservations): A microservice responsible for managing the reservation process at the hotel. [![Docker Hub](https://img.shields.io/badge/docker-hub-black.svg)](https://hub.docker.com/repository/docker/wesleycosta/orangotango-reservations)
- [**orangotango-notifications**](https://github.com/wesleycosta/orangotango-notifications): A microservice responsible for sending notifications.
- [**orangotango-packages**](https://github.com/wesleycosta/orangotango-packages): Shared packages among the microservices, providing common functionalities, which are:
  - **`Orangotango.Core`**: The kernel package for microservices, encompassing abstractions for messaging, events, repositories, services, aggregations, and more. [![NuGet](https://img.shields.io/nuget/v/Orangotango.Core.svg)](https://www.nuget.org/packages/Orangotango.Core)

  - **`Orangotango.Api`**: This package provides APIs centralizing Swagger configuration, standardized response patterns, middleware for logging incoming requests and outgoing responses. [![NuGet](https://img.shields.io/nuget/v/Orangotango.Api.svg)](https://www.nuget.org/packages/Orangotango.Api)

  - **`Orangotango.Events`**: Contains all solution events, establishing contracts for easy integration via messaging topology, facilitating data replication across microservices. [![NuGet](https://img.shields.io/nuget/v/Orangotango.Events.svg)](https://www.nuget.org/packages/Orangotango.Events)

  - **`Orangotango.Infra`**: Includes infrastructure-related configurations such as Entity Framework contexts, ELK-based logging configuration, Messaging using Mass Transit and RabbitMQ, among others. [![NuGet](https://img.shields.io/nuget/v/Orangotango.Infra.svg)](https://www.nuget.org/packages/Orangotango.Infra)

## Architecture

Below is a diagram of the application architecture, illustrating how the microservices communicate with each other:

[![Blueprint](https://github.com/wesleycosta/orangotango/blob/main/images/diagrams/blueprint.drawio.png)](https://github.com/wesleycosta/orangotango/blob/main/images/diagrams/blueprint.drawio.png)

Orangotango's microservices, implemented in .NET, are designed using a Hexagonal / Event-Driven Architecture (EDA). 

The system emphasizes responsibility separation, adhering to SOLID, Clean Code, and Domain-Driven Design (DDD) principles. The microservices are organized into distinct layers:

1. **Presentation Layer**: Includes a Web API with controllers and input models (DTOs) defining endpoint contracts.
2. **Application Layer**: Consists of Command Handlers, Mappers, Results, and Services.
3. **Domain Layer**: Comprises Entities, Commands, Validations, and Repository Abstractions.
4. **Infrastructure Layer**: Implements Repositories, the EF Context, and a Messaging Bus.

See below an example of implementation using the aforementioned layers in orangotango-rooms:
![DotnetLayers](https://github.com/wesleycosta/orangotango/blob/main/images/diagrams/dotnet_layers.png)

### Design Patterns and Principles

- Hexagonal / Event-Driven Architecture (EDA).
- CQRS (Command Query Responsibility Segregation), DDD, SOLID, and Clean Code principles.
- Service Layer, Repository Pattern, Notification Pattern, and Unit Of Work.
- Resilience best practices including Retry Pattern, Circuit Breaker, and Exponential Backoff.

Feel free to contribute to this project. For more information, refer to the individual repositories of each project.

## How to Run with Docker

To run the project using Docker, you can use the `docker-compose/docker-compose-full.yml` file, which sets up all the necessary services for Orangotango. Follow the steps below:

1. **Make sure you have Docker and Docker Compose installed.**

   - To install Docker, follow the instructions [here](https://docs.docker.com/get-docker/).
   - To install Docker Compose, follow the instructions [here](https://docs.docker.com/compose/install/).

2. **Clone the Orangotango repository.**

   ```bash
   git clone https://github.com/wesleycosta/orangotango.git
   cd orangotango
   ```

3. **Run Docker Compose.**

   In the root directory of the project, run the command below to start all the services defined in the `docker-compose-full.yml` file:

   ```bash
   docker-compose -f docker-compose/docker-compose-full.yml up
   ```

   This will start the following services:
   - **Elasticsearch**
   - **Kibana**
   - **SQL Server**
   - **RabbitMQ**
   - **orangotango-rooms**
   - **orangotango-reservations**
   - **orangotango-api-gateway**
   - **orangotango-app**

4. **Access the services.**

   - **Web Application (SPA)**: [http://localhost:81](http://localhost:81)
   - **API Gateway**: [http://localhost:8080](http://localhost:8080)
   - **Rooms Service**: [http://localhost:8081](http://localhost:8081)
   - **Reservations Service**: [http://localhost:8082](http://localhost:8082)
   - **Elasticsearch**: [http://localhost:9200](http://localhost:9200)
   - **Kibana**: [http://localhost:5601](http://localhost:5601)
   - **RabbitMQ Management**: [http://localhost:15672](http://localhost:15672)

5. **Shut down the services.**

   To stop all the services, press `Ctrl+C` in the terminal where the services are running, and then run:

   ```bash
   docker-compose -f docker-compose/docker-compose-full.yml down
   ```
   
## How to Contribute

1. Fork the project
2. Create a branch for your feature (`git checkout -b feature/new-feature`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to the branch (`git push origin feature/new-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
