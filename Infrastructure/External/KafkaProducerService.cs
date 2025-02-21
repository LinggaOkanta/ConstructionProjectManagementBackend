// Infrastructure/External/KafkaProducerService.cs
using Confluent.Kafka;

public class KafkaProducerService
{
    private readonly ProducerConfig _config;

    public KafkaProducerService()
    {
        _config = new ProducerConfig { BootstrapServers = "localhost:9092" };
    }

    public async Task SendToKafkaAsync(string topic, string message)
    {
        using (var producer = new ProducerBuilder<Null, string>(_config).Build())
        {
            var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            Console.WriteLine($"Delivered to {result.TopicPartitionOffset}");
        }
    }
}