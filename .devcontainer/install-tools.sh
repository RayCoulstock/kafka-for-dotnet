#!/usr/bin/env bash
set -u

KAFKA_VERSION="${KAFKA_VERSION:-3.7.0}"
SCALA_VERSION="${SCALA_VERSION:-2.13}"
KAFKA_DIR="/opt/kafka_${SCALA_VERSION}-${KAFKA_VERSION}"

log() { printf '[post-create] %s\n' "$*"; }

log "Ensuring training scripts are executable"
chmod +x scripts/*.sh 2>/dev/null || true

if command -v kafka-topics >/dev/null 2>&1; then
  log "Kafka CLI tools are already installed"
else
  log "Installing lightweight helper packages and Kafka CLI tools"
  sudo apt-get update || true
  sudo apt-get install -y --no-install-recommends curl jq netcat-openbsd openjdk-17-jre || true

  if [ ! -d "$KAFKA_DIR" ]; then
    curl -fsSL "https://archive.apache.org/dist/kafka/${KAFKA_VERSION}/kafka_${SCALA_VERSION}-${KAFKA_VERSION}.tgz" \
      | sudo tar -xz -C /opt || true
  fi

  if [ -d "$KAFKA_DIR" ]; then
    sudo ln -sfn "$KAFKA_DIR" /opt/kafka
    echo 'export PATH=$PATH:/opt/kafka/bin' | sudo tee /etc/profile.d/kafka-tools.sh >/dev/null
    log "Kafka CLI tools installed at /opt/kafka/bin"
  else
    log "Kafka CLI install skipped; Docker-based scripts still work without host Kafka tools"
  fi
fi

log "Restoring .NET solution packages"
dotnet restore apps/dotnet/KafkaTraining.sln || log "dotnet restore failed; retry after the Codespace finishes initializing"

log "Post-create setup complete"
exit 0
