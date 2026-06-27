#!/usr/bin/env bash
set -euo pipefail
TOPICS=(orders customers products processed-orders reliability-demo group-demo manual-offset-demo)
for topic in "${TOPICS[@]}"; do
  docker exec kafka kafka-topics --bootstrap-server localhost:9092 --create --if-not-exists --topic "$topic" --partitions 3 --replication-factor 1
done
