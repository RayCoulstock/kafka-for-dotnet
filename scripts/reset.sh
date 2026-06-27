#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/common.sh"
"$ROOT_DIR/scripts/down.sh"
docker volume prune -f
rm -f "$ROOT_DIR/connect/input"/* "$ROOT_DIR/connect/output"/* 2>/dev/null || true
