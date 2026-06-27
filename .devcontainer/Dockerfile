FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm

ARG KAFKA_VERSION=3.7.0
ARG SCALA_VERSION=2.13
RUN apt-get update \
    && apt-get install -y --no-install-recommends curl jq netcat-openbsd openjdk-17-jre \
    && curl -fsSL "https://archive.apache.org/dist/kafka/${KAFKA_VERSION}/kafka_${SCALA_VERSION}-${KAFKA_VERSION}.tgz" \
      | tar -xz -C /opt \
    && ln -s "/opt/kafka_${SCALA_VERSION}-${KAFKA_VERSION}" /opt/kafka \
    && echo 'export PATH=$PATH:/opt/kafka/bin' > /etc/profile.d/kafka-tools.sh \
    && apt-get clean && rm -rf /var/lib/apt/lists/*
ENV PATH="${PATH}:/opt/kafka/bin"
