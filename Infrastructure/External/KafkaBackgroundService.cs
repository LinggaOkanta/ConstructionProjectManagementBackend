// Infrastructure/External/KafkaBackgroundService.cs
using Microsoft.Extensions.Hosting;

public class KafkaBackgroundService : BackgroundService
{
    private readonly KafkaConsumerService _kafkaConsumer;

    public KafkaBackgroundService(KafkaConsumerService kafkaConsumer)
    {
        _kafkaConsumer = kafkaConsumer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() => _kafkaConsumer.Consume("es.construction.hbx"), stoppingToken);
    }
}