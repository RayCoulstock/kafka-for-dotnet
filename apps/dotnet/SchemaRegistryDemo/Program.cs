using Avro;
using Avro.Generic;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

var schema = (RecordSchema)Schema.Parse("""
{"type":"record","name":"Order","namespace":"Training","fields":[{"name":"orderId","type":"string"},{"name":"customerId","type":"string"},{"name":"total","type":"double"}]}
""");
var registry = new CachedSchemaRegistryClient(new SchemaRegistryConfig { Url = "http://localhost:8081" });
using var producer = new ProducerBuilder<string, GenericRecord>(new ProducerConfig { BootstrapServers = "localhost:9092" })
    .SetValueSerializer(new AvroSerializer<GenericRecord>(registry))
    .Build();
var record = new GenericRecord(schema);
record.Add("orderId", Guid.NewGuid().ToString("N"));
record.Add("customerId", "C001");
record.Add("total", 42.50);
var report = await producer.ProduceAsync("avro-orders", new Message<string, GenericRecord> { Key = "C001", Value = record });
Console.WriteLine($"Wrote Avro order to {report.TopicPartitionOffset}");
