// Infrastructure/External/KafkaConsumerService.cs
using Confluent.Kafka;
using ConstructionProjectManagement.Domain.Entities;
using Newtonsoft.Json;

public class KafkaConsumerService
{
    private readonly ConsumerConfig _config;
    private readonly ElasticSearchService _elasticSearchService;

    public KafkaConsumerService(ElasticSearchService elasticSearchService)
    {
        _config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "construction-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _elasticSearchService = elasticSearchService;
    }

    public void Consume(string topic)
    {
        using (var consumer = new ConsumerBuilder<Ignore, string>(_config).Build())
        {
            consumer.Subscribe(topic);

            while (true)
            {
                var result = consumer.Consume();
                var project = JsonConvert.DeserializeObject<ConstructionProject>(result.Message.Value);
                _elasticSearchService.IndexProjectAsync(project).Wait(); 
                Console.WriteLine($"Consumed: {result.Message.Value}");
            }
        }
    }
}