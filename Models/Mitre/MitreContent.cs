using Newtonsoft.Json;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreContent
    {
        [JsonProperty("object_modified")]
        public string ObjectModified { get; set; }
        [JsonProperty("object_ref")]
        public string ObjectRef { get; set; }
    }
}
