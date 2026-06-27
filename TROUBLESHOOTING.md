# Troubleshooting

## Docker is not running

Run `docker info`. In Codespaces, rebuild the container if Docker is unavailable.

## Containers do not start

Run `docker compose -f compose/kafka-single.yml ps` and `docker logs kafka`. If the environment is confused, run `./scripts/reset.sh` and then `./scripts/up-basic.sh`.

## Port conflicts

Kafka UI uses `8080`, Schema Registry uses `8081`, Kafka Connect uses `8083`, ksqlDB uses `8088`, and Kafka uses `9092`. Stop local services that use these ports or change the port mapping in the compose file.

## Kafka is unavailable

Check advertised listeners. C# apps run from the Codespace host and use `localhost:9092`. Other containers use `kafka:29092`.

## Schema Registry is unavailable

Start it with `./scripts/up-schema.sh`, then check `curl http://localhost:8081/subjects`.

## Kafka Connect is unavailable

Start it with `./scripts/up-connect.sh`, then check `curl http://localhost:8083/connectors`. The sample file source connector reads `/data/input/orders.txt` inside the container, mapped from `connect/input/orders.txt`.

## ksqlDB is unavailable

Start it with `./scripts/up-ksqldb.sh`, then check `curl http://localhost:8088/info`.

## Reset everything

Run `./scripts/reset.sh`. This removes training containers and Docker volumes, then you can start again with `./scripts/up-basic.sh`.
