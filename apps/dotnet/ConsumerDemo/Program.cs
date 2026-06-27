using Confluent.Kafka;

var config = new ConsumerConfig { BootstrapServers = "localhost:9092", GroupId = "consumer-demo", AutoOffsetReset = AutoOffsetReset.Earliest };
using var consumer = new ConsumerBuilder<string, string>(config).Build();
using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };
consumer.Subscribe(args.FirstOrDefault() ?? "orders");
Console.WriteLine("Consuming. Press Ctrl+C to stop.");
try
{
    while (!cts.IsCancellationRequested)
    {
        var result = consumer.Consume(cts.Token);
        Console.WriteLine($"{result.TopicPartitionOffset} key={result.Message.Key} value={result.Message.Value}");
    }
}
catch (OperationCanceledException) { }
finally { consumer.Close(); }
