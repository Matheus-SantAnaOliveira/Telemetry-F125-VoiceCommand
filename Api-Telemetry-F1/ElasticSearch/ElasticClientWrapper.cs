using Nest;

namespace Api_Telemetry_F1.Elastic
{
    public class ElasticClientWrapper
    {
        public IElasticClient Client { get; }

        public ElasticClientWrapper()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("telemetryf1-data")
                .PrettyJson(); 

            Client = new ElasticClient(settings);
        }
    }
}