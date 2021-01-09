# Camadas e Responsabilidades

- 1 - APIs
	- Web API que atende requisições feitas pelo Web App;
- 2 - Workers
	- Worker Services que consomem uma fila do RabbitMQ e processa dados em backgroud;
- 3 - Shared
	- Camada compartilhada entre outros projetos
- 4 - Business
	- Camada de negócios, possue os models, commands e queries;
- 5 - Data
	- Camada de acesso a dados;
- 6 - Tests
	- Camada de testes de unidades;
