using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using SampleDotNetDynamo.Models.Entities;
using System.Net;
using System.Text.Json;

namespace SampleDotNetDynamo.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly string _tableName = "customers";
        private readonly IAmazonDynamoDB _dynamoDB;

        public CustomerRepository(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDB = dynamoDB;
        }

        public async Task<bool> CreateAsync(Customer customer)
        {
            var customerAsJson = JsonSerializer.Serialize(customer);
            var customerAsAttributes = Document.FromJson(customerAsJson).ToAttributeMap();
            var createItemRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = customerAsAttributes
            };

            var response = await _dynamoDB.PutItemAsync(createItemRequest);

            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var scanRequest = new ScanRequest
            {
                TableName = _tableName
            };

            var response = await _dynamoDB.ScanAsync(scanRequest);

            return response.Items.Select(item =>
            {
                var json = Document.FromAttributeMap(item).ToJson();
                return JsonSerializer.Deserialize<Customer>(json)!;
            });
        }

        public async Task<Customer?> GetById(Guid id)
        {
            var getItemRequest = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "pk", new AttributeValue { S = id.ToString() } },
                    { "sk", new AttributeValue { S = id.ToString() } }
                }
            };

            var response = await _dynamoDB.GetItemAsync(getItemRequest);
            if(response.Item.Count == 0)
            {
                return null;
            }

            var document = Document.FromAttributeMap(response.Item);
            return JsonSerializer.Deserialize<Customer>(document.ToJson());
        }
    }
}
