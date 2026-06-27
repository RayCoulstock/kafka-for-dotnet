#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/common.sh"
compose -f "$ROOT_DIR/compose/kafka-single.yml" up -d
wait_for_kafka
