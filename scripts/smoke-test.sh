#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/common.sh"
docker info >/dev/null
docker exec kafka kafka-broker-api-versions --bootstrap-server localhost:9092 >/dev/null
docker exec kafka kafka-topics --bootstrap-server localhost:9092 --create --if-not-exists --topic smoke-test --partitions 1 --replication-factor 1 >/dev/null
echo "hello from smoke test" | docker exec -i kafka kafka-console-producer --bootstrap-server localhost:9092 --topic smoke-test
docker exec kafka bash -lc 'kafka-console-consumer --bootstrap-server localhost:9092 --topic smoke-test --from-beginning --max-messages 1 --timeout-ms 10000' | tee /tmp/kafka-smoke.out
rg "hello from smoke test" /tmp/kafka-smoke.out >/dev/null
echo "Smoke test passed."
