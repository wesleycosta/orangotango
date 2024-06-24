# Orangotango

![Logo](https://github.com/wesleycosta/orangotango/raw/main/images/logos/logo_full.png)

**Orangotango** is a hotel reservation system that utilizes a modern and scalable microservices architecture.

## Projects

Orangotango is composed of six main projects, each playing a specific role in the system's architecture:

- [**orangotango-app**](https://github.com/wesleycosta/orangotango-app): A Single Page Application (SPA) built with Angular that communicates with the **orangotango-api-gateway**.
- [**orangotango-core**](https://github.com/wesleycosta/orangotango-core): Shared packages among the microservices, providing common functionalities.
- [**orangotango-api-gateway**](https://github.com/wesleycosta/orangotango-api-gateway): An API gateway using Ocelot that manages communication between external services and internal microservices.
- [**orangotango-rooms**](https://github.com/wesleycosta/orangotango-rooms): A microservice responsible for providing information about the available rooms at the hotel.
- [**orangotango-reservations**](https://github.com/wesleycosta/orangotango-reservations): A microservice responsible for managing the reservation process at the hotel.
- [**orangotango-notifications**](https://github.com/wesleycosta/orangotango-notifications): A microservice responsible for sending notifications.

## Architecture

Below is a diagram of the application architecture, illustrating how the microservices communicate with each other:

[![Blueprint](https://github.com/wesleycosta/orangotango/blob/main/images/diagrams/blueprint.drawio.png)](https://github.com/wesleycosta/orangotango/blob/main/images/diagrams/blueprint.drawio.png)

---

Feel free to contribute to this project. For more information, refer to the individual repositories of each project.

## How to Contribute

1. Fork the project
2. Create a branch for your feature (`git checkout -b feature/new-feature`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to the branch (`git push origin feature/new-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
