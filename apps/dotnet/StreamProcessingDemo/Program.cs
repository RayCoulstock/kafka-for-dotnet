using Confluent.Kafka;

var consumerConfig = new ConsumerConfig { BootstrapServers = "localhost:9092", GroupId = "stream-processing-demo", AutoOffsetReset = AutoOffsetReset.Earliest };
var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
using var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
using var producer = new ProducerBuilder<string, string>(producerConfig).Build();
consumer.Subscribe("orders");
Console.WriteLine("Transforming orders into processed-orders.");
while (true)
{
    var input = consumer.Consume();
    var output = $"{{\"processedAt\":\"{DateTimeOffset.UtcNow:O}\",\"original\":{input.Message.Value}}}";
    var report = await producer.ProduceAsync("processed-orders", new Message<string, string> { Key = input.Message.Key, Value = output });
    Console.WriteLine($"Processed {input.TopicPartitionOffset} -> {report.TopicPartitionOffset}");
}
