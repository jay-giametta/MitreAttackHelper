using MitreAttackHelper.Models.Stix;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreBundle : Bundle
    {
        [JsonProperty("objects")]
        public new IEnumerable<MitreStixGeneric> Objects { get; set; }
    }
}
