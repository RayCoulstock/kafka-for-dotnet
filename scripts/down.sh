#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/common.sh"
compose -f "$ROOT_DIR/compose/kafka-single.yml" -f "$ROOT_DIR/compose/schema-registry.yml" -f "$ROOT_DIR/compose/kafka-connect.yml" -f "$ROOT_DIR/compose/ksqldb.yml" down --remove-orphans || true
compose -f "$ROOT_DIR/compose/kafka-cluster.yml" down --remove-orphans || true
compose -f "$ROOT_DIR/compose/flink.yml" down --remove-orphans || true
