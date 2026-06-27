#!/usr/bin/env bash
set -euo pipefail
ROOT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
compose() { docker compose "$@"; }
wait_for_kafka() {
  echo "Waiting for Kafka..."
  for _ in {1..60}; do
    if docker exec kafka kafka-broker-api-versions --bootstrap-server localhost:9092 >/dev/null 2>&1; then echo "Kafka is ready"; return 0; fi
    sleep 2
  done
  echo "Kafka did not become ready" >&2; return 1
}
