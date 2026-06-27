# Kafka for .NET: Two-Day Codespaces Training

This repository is a ready-to-run classroom environment for C#/.NET developers learning Apache Kafka. Each student opens an isolated GitHub Codespace, starts Kafka with simple scripts, and adds components as the course progresses.

## What you get

- Kafka in KRaft mode, no ZooKeeper.
- Kafka UI at <http://localhost:8080>.
- .NET 8 C# demos for producers, consumers, consumer groups, offsets, reliability, Schema Registry, Kafka Connect, and stream processing.
- Progressive Docker Compose files so later modules add services without rebuilding the environment.
- A separate three-broker cluster demo that runs inside one Codespace for replication and failover exercises.

## Quick start

```bash
./scripts/up-basic.sh
./scripts/create-topics.sh
./scripts/smoke-test.sh
```

Open Kafka UI from the forwarded port `8080`.

## Run C# examples

```bash
cd apps/dotnet/ProducerDemo
dotnet run

cd ../ConsumerDemo
dotnet run
```

Most demos default to `localhost:9092` and can be read in a single `Program.cs` file.

## Add services as the course progresses

```bash
./scripts/up-schema.sh     # Adds Schema Registry on 8081
./scripts/up-connect.sh    # Adds Kafka Connect on 8083
./scripts/up-ksqldb.sh     # Adds ksqlDB on 8088
./scripts/up-cluster.sh    # Separate three-broker cluster demo
```

## Stop or reset

```bash
./scripts/down.sh
./scripts/reset.sh
```

`reset.sh` removes containers and prunes Docker volumes. Use it when you want a clean classroom environment.

## Course flow

1. `labs/00-Environment.md` - Codespaces, scripts, Kafka UI, smoke test.
2. `labs/01-Kafka-Basics.md` - topics, partitions, records.
3. `labs/02-Producers.md` - keys, partitions, delivery reports.
4. `labs/03-Consumers.md` - polling, offsets, shutdown.
5. `labs/04-Consumer-Groups.md` - group membership and rebalancing.
6. `labs/05-Replication.md` - three-broker cluster, ISR, failover.
7. `labs/06-Schema-Registry.md` - Avro and compatibility.
8. `labs/07-Kafka-Connect.md` - Connect REST API and file source connector.
9. `labs/08-Stream-Processing.md` - consume-process-produce pipelines and ksqlDB.

## Networking note

Do not join all students' Codespaces into one shared Kafka cluster. Kafka needs stable advertised broker addresses. This repository prioritizes reliable single-student environments and includes a local three-broker cluster for demonstrations.
