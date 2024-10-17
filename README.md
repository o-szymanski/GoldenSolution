# GoldenSolution (In progress)

Welcome to Golden Solution, a comprehensive restaurant designed to simplify and enhance the dining experience.

## Screenshots

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

## Technology Stack

SQL Server / Entity Framework

HTML / CSS / TypeScript / React

Tailwind

Redis  

RabbitMQ

Serilog / Elastic Search / Kibana

## Run locally

Download

Docker desktop \
Node.js

Clone the project

```bash
git clone https://github.com/o-szymanski/GoldenSolution.git
```

Go to the project directory

```bash
cd Docker
```

Start Containers

```bash
docker-compose up -d / docker-compose up --build
```

Ports under which applications are located \
[Website](http://localhost:5173/) \
[Kibana](http://localhost:5601/app/home#/) \
[Api](http://localhost:8080/swagger/index.html) \
[RabbitMQ](http://localhost:15672/)

## Manual Access

MSSQL - Server name : 127.0.0.1, 1433 / sa / ***

## Authors

[@o-szymanski](https://github.com/o-szymanski)

## License

[MIT](https://choosealicense.com/licenses/mit/)
