# Mikroservic Demo Projesi

Bu proje, microservis mimarisini işleyen bir demo projesidir. Proje kapsamında RabbitMQ, Docker, Kubernetes, gRPC ve mimariler hakkında çeşitli örnekler bulabilirsiniz.

## İçindekiler

- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Özellikler](#özellikler)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)

## Kurulum

### Gereksinimler

- [Docker](https://www.docker.com/)
- [Kubernetes](https://kubernetes.io/)
- [RabbitMQ](https://www.rabbitmq.com/)
- [gRPC](https://grpc.io/)

### Adımlar

1. Bu repoyu klonlayın:
    ```bash
    git clone https://github.com/kullanici/demo-projesi.git
    cd demo-projesi
    ```

2. Docker konteynerlerini başlatın:
    ```bash
    docker-compose up -d
    ```

3. Kubernetes cluster'ını konfigüre edin ve deploy edin:
    ```bash
    kubectl apply -f k8s/
    ```

## Kullanım

Proje içerisindeki örnekleri çalıştırmak ve incelemek için aşağıdaki adımları takip edebilirsiniz:

1. RabbitMQ kullanarak mesaj kuyruğunu başlatın:
    ```bash
    docker-compose up rabbitmq
    ```

2. gRPC servislerini çalıştırın:
    ```bash
    go run grpc_server/main.go
    ```

3. Kubernetes üzerinde deploy edilen servislerin durumunu kontrol edin:
    ```bash
    kubectl get pods
    ```

## Özellikler

- Microservis mimarisi
- RabbitMQ ile mesaj kuyruğu yönetimi
- Docker konteynerizasyonu
- Kubernetes ile ölçeklenebilir dağıtım
- gRPC ile yüksek performanslı servisler

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir `issue` açın veya bir `pull request` gönderin. Her türlü katkı değerlidir!

## Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.


# En
# Microservice Demo Project

This project is a demo project that explores microservice architecture. In this project, you can find various examples of RabbitMQ, Docker, Kubernetes, gRPC, and architectures.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)
- [License](#license)

## Installation

### Requirements

- [Docker](https://www.docker.com/)
- [Kubernetes](https://kubernetes.io/)
- [RabbitMQ](https://www.rabbitmq.com/)
- [gRPC](https://grpc.io/)

### Steps

1. Clone this repository:
    ```bash
    git clone https://github.com/username/demo-project.git
    cd demo-project
    ```

2. Start the Docker containers:
    ```bash
    docker-compose up -d
    ```

3. Configure and deploy the Kubernetes cluster:
    ```bash
    kubectl apply -f k8s/
    ```

## Usage

To run and examine the examples within the project, follow these steps:

1. Start the message queue using RabbitMQ:
    ```bash
    docker-compose up rabbitmq
    ```

2. Run the gRPC services:
    ```bash
    go run grpc_server/main.go
    ```

3. Check the status of the services deployed on Kubernetes:
    ```bash
    kubectl get pods
    ```

## Features

- Microservice architecture
- Message queue management with RabbitMQ
- Docker containerization
- Scalable deployment with Kubernetes
- High-performance services with gRPC

## Contributing

If you want to contribute, please open an `issue` or send a `pull request`. All contributions are welcome!

## License

This project is licensed under the [MIT License](LICENSE).

