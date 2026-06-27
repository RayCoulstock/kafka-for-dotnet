using Confluent.Kafka;

var config = new ProducerConfig { BootstrapServers = "localhost:9092", Acks = Acks.All, EnableIdempotence = true, MessageSendMaxRetries = 5, LingerMs = 5 };
using var producer = new ProducerBuilder<string, string>(config).Build();
for (var i = 0; i < 20; i++)
{
    producer.Produce("reliability-demo", new Message<string, string> { Key = $"order-{i}", Value = $"reliable message {i}" },
        r => Console.WriteLine(r.Error.IsError ? $"Failed: {r.Error.Reason}" : $"Ack from {r.TopicPartitionOffset}"));
}
producer.Flush(TimeSpan.FromSeconds(10));
