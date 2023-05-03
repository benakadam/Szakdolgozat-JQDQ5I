using Confluent.Kafka;
using Newtonsoft.Json;
namespace Projekt.Communication;

public class KafkaCommunication
{
    readonly string _url;
    readonly string _topic;
    public KafkaCommunication(string url, string topic)
    {
        _url = url;
        _topic = topic;
    }

    /// <summary>
    /// Elküldi a paraméterben kapott osztályt, szerializálva egy topic-ra
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public async Task KafkaProducer<T>(T result) where T : class
    {
        var config = new ProducerConfig
        {
            BootstrapServers = _url
        };

        var producer = new ProducerBuilder<Null, string>(config).Build();

        try
        {
            var response = await producer.ProduceAsync(_topic, new Message<Null, string>
            {
                Value = JsonConvert.SerializeObject(result)
            });

        }
        catch (ProduceException<Null, string> exc)
        {
            throw new System.Exception("Hiba a küldés során" + exc.Message);
        }
    }
}