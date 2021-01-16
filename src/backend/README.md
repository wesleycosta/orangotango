# Camadas e Responsabilidades

- 1 - APIs
	- Web API que atende requisições feitas pelo Web App;
- 2 - Workers
	- Worker Services que processa dados em backgroud via AMQP com RabbitMQ;
- 3 - Shared
	- Camada compartilhada entre projetos;
- 4 - Business
	- Camada com as regras de negócios;
- 5 - Data
	- Camada de acesso a dados;
- 6 - Tests
	- Camada de testes de unidades.
