using Confluent.Kafka;

var memberName = args.FirstOrDefault() ?? Environment.MachineName;
var config = new ConsumerConfig { BootstrapServers = "localhost:9092", GroupId = "group-demo", ClientId = memberName, AutoOffsetReset = AutoOffsetReset.Earliest };
using var consumer = new ConsumerBuilder<string, string>(config)
    .SetPartitionsAssignedHandler((_, partitions) => Console.WriteLine($"{memberName} assigned: {string.Join(", ", partitions)}"))
    .SetPartitionsRevokedHandler((_, partitions) => Console.WriteLine($"{memberName} revoked: {string.Join(", ", partitions)}"))
    .Build();
consumer.Subscribe("group-demo");
Console.WriteLine($"Consumer {memberName} running. Start another terminal with a different name.");
while (true)
{
    var result = consumer.Consume();
    Console.WriteLine($"{memberName} read {result.Message.Value} from {result.TopicPartitionOffset}");
}
