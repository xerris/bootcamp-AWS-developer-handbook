using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace DynamoDB.Intro.Services.Repositories
{
    public interface IDynamoDbContextProvider
    {
        public IDynamoDBContext Create();
    }

    public class DynamoDbContextProvider : IDynamoDbContextProvider
    {
        private readonly AmazonDynamoDBClient client;

        public DynamoDbContextProvider(IApplicationConfig config)
        {
            client = new AmazonDynamoDBClient(new AmazonDynamoDBConfig {RegionEndpoint = config.AwsRegion});
        }

        public IDynamoDBContext Create()
        {
            return new DynamoDBContext(client);
        }
    }
}