using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace SampleDotNetDynamo.Data
{
    public class AppDbContext: DynamoDBContext
    {
        public AppDbContext(IAmazonDynamoDB dynamoDBClient, DynamoDBContextConfig config): base(dynamoDBClient, config)
        {
        }
    }
}
