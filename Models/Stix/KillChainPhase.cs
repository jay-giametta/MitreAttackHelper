using Newtonsoft.Json;

namespace MitreAttackHelper.Models.Stix
{
    public class KillChainPhase
    {
        [JsonProperty("kill_chain_name")]
        public string KillChainName { get; set; }
        [JsonProperty("phase_name")]
        public string PhaseName { get; set; }
    }
}
