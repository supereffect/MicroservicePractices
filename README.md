TR
Mikroservis Demo Projesi
Bu proje, microservis mimarisini işleyen bir demo projesidir. Proje kapsamında RabbitMQ, Docker, Kubernetes, gRPC ve mimariler hakkında çeşitli örnekler bulabilirsiniz.

İçindekiler
Kurulum
Kullanım
Özellikler
Katkıda Bulunma
Lisans
Kurulum
Gereksinimler
Docker
Kubernetes
RabbitMQ
gRPC
Adımlar
Bu repoyu klonlayın:

git clone https://github.com/kullanici/demo-projesi.git
cd demo-projesi
Docker konteynerlerini başlatın:

docker-compose up -d
Kubernetes cluster'ını konfigüre edin ve deploy edin:

kubectl apply -f k8s/
Kullanım
Proje içerisindeki örnekleri çalıştırmak ve incelemek için aşağıdaki adımları takip edebilirsiniz:

RabbitMQ kullanarak mesaj kuyruğunu başlatın:

docker-compose up rabbitmq
gRPC servislerini çalıştırın:

go run grpc_server/main.go
Kubernetes üzerinde deploy edilen servislerin durumunu kontrol edin:

kubectl get pods
Özellikler
Microservis mimarisi
RabbitMQ ile mesaj kuyruğu yönetimi
Docker konteynerizasyonu
Kubernetes ile ölçeklenebilir dağıtım
gRPC ile yüksek performanslı servisler
Katkıda Bulunma
Katkıda bulunmak isterseniz, lütfen bir issue açın veya bir pull request gönderin. Her türlü katkı değerlidir!

Lisans
Bu proje MIT Lisansı ile lisanslanmıştır.

EN
Microservice Demo Project
This project is a demo project that explores microservice architecture. In this project, you can find various examples of RabbitMQ, Docker, Kubernetes, gRPC, and architectures.

Table of Contents
Installation
Usage
Features
Contributing
License
Installation
Requirements
Docker
Kubernetes
RabbitMQ
gRPC
Steps
Clone this repository:

git clone https://github.com/username/demo-project.git
cd demo-project
Start the Docker containers:

docker-compose up -d
Configure and deploy the Kubernetes cluster:

kubectl apply -f k8s/
Usage
To run and examine the examples within the project, follow these steps:

Start the message queue using RabbitMQ:

docker-compose up rabbitmq
Run the gRPC services:

go run grpc_server/main.go
Check the status of the services deployed on Kubernetes:

kubectl get pods
Features
Microservice architecture
Message queue management with RabbitMQ
Docker containerization
Scalable deployment with Kubernetes
High-performance services with gRPC
Contributing
If you want to contribute, please open an issue or send a pull request. All contributions are welcome!

License
This project is licensed under the MIT License.

