# Unsupported experiment: cross-Codespace Kafka networking

Kafka brokers advertise TCP addresses to clients. Public Codespaces ports can be useful for HTTP demos, but they are not a reliable foundation for a multi-student Kafka cluster because broker addresses, port forwarding, and advertised listener metadata must remain stable.

If you experiment anyway, use one instructor-owned Codespace, publish broker ports, configure explicit advertised listeners, and expect client connectivity issues. This is not part of the supported course path.
