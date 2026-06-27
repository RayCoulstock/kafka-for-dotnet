#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/common.sh"
"$ROOT_DIR/scripts/up-basic.sh"
compose -f "$ROOT_DIR/compose/kafka-single.yml" -f "$ROOT_DIR/compose/ksqldb.yml" up -d
