using Newtonsoft.Json;

namespace MitreAttackHelper.Models.Stix
{
    public class ExternalReference
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
