#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/common.sh"
"$ROOT_DIR/scripts/up-schema.sh"
compose -f "$ROOT_DIR/compose/kafka-single.yml" -f "$ROOT_DIR/compose/schema-registry.yml" -f "$ROOT_DIR/compose/kafka-connect.yml" up -d
