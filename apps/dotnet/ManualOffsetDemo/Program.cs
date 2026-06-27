using Confluent.Kafka;

var config = new ConsumerConfig { BootstrapServers = "localhost:9092", GroupId = "manual-offset-demo", EnableAutoCommit = false, AutoOffsetReset = AutoOffsetReset.Earliest };
using var consumer = new ConsumerBuilder<string, string>(config).Build();
consumer.Subscribe("manual-offset-demo");
Console.WriteLine("Manual commits enabled. Pass --no-commit to replay on restart.");
var commit = !args.Contains("--no-commit");
while (true)
{
    var result = consumer.Consume();
    Console.WriteLine($"Processing {result.Message.Value} at {result.TopicPartitionOffset}");
    if (commit)
    {
        consumer.Commit(result);
        Console.WriteLine($"Committed {result.TopicPartitionOffset}");
    }
}
