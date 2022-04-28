using Newtonsoft.Json;

namespace MitreAttackHelper.Models.Stix
{
    public class MarkingObject
    {
        [JsonProperty("statement")]
        public string Statement { get; set; }
    }
}
