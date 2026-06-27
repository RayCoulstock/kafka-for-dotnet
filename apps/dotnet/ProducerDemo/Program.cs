using Confluent.Kafka;

var config = new ProducerConfig { BootstrapServers = "localhost:9092", ClientId = "producer-demo" };
using var producer = new ProducerBuilder<string, string>(config).Build();
var topic = args.FirstOrDefault() ?? "orders";

for (var i = 1; i <= 10; i++)
{
    var key = $"customer-{i % 3}";
    var value = $"{{\"orderId\":{i},\"total\":{Random.Shared.Next(10, 200)}}}";
    var report = await producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = value });
    Console.WriteLine($"Delivered key={key} to {report.TopicPartitionOffset}");
}
producer.Flush(TimeSpan.FromSeconds(5));
