# Delivery de Comida con Kafka

## Descripción

Sistema distribuido de procesamiento de pedidos utilizando Apache Kafka.
La API recibe pedidos, los publica en Kafka y un Worker los consume para procesarlos.

## Tecnologías

- .NET 8
- ASP.NET Core Web API
- Apache Kafka
- Docker
- Confluent.Kafka

## Arquitectura

Cliente → API → Kafka → Worker

## Ejecución

### 1. Levantar Kafka

Ejecutar:

docker compose up -d


### 2. Crear topic

docker exec -it broker /opt/kafka/bin/kafka-topics.sh \
--create \
--topic pedidos-topic \
--bootstrap-server localhost:9092 \
--partitions 3 \
--replication-factor 1


### 3. Ejecutar API

Abrir:

Delivery.Api


### 4. Ejecutar Worker

Abrir:

Delivery.Worker


