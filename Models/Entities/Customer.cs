using System.Text.Json.Serialization;

namespace SampleDotNetDynamo.Models.Entities
{
    public class Customer
    {

        [JsonPropertyName("pk")]
        public string Pk => Id.ToString();

        [JsonPropertyName("sk")]
        public string Sk => Id.ToString();
        public Guid Id { get; set; } = default!;

        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
