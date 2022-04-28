using MitreAttackHelper.Models.Stix;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreStixGeneric : StixGeneric
    {
        [JsonProperty("x_mitre_aliases")]
        public IEnumerable<string> MitreAlases { get; set; }
        [JsonProperty("x_mitre_attack_spec_version")]
        public string MitreAttackSpecVersion { get; set; }
        [JsonProperty("x_mitre_contents")]
        public IEnumerable<MitreContent> MitreContents { get; set; }
        [JsonProperty("x_mitre_contributers")]
        public IEnumerable<string> MitreContributers { get; set; }
        [JsonProperty("x_mitre_data_source_ref")]
        public string MitreDataSourceRef { get; set; }
        [JsonProperty("x_mitre_data_sources")]
        public IEnumerable<string> MitreDataSources { get; set; }
        [JsonProperty("x_mitre_defense_bypassed")]
        public IEnumerable<string> MitreDefenseByPassed { get; set; }
        [JsonProperty("x_mitre_deprecated")]
        public bool? MitreDeprecated { get; set; }
        [JsonProperty("x_mitre_detection")]
        public string MitreDetection { get; set; }
        [JsonProperty("x_mitre_domains")]
        public IEnumerable<string> MitreDomains { get; set; }
        [JsonProperty("x_mitre_is_subtechnique")]
        public bool? MitreIsSubTechnique { get; set; }
        [JsonProperty("x_mitre_modified_by_ref")]
        public string MitreModifiedByRef { get; set; }
        [JsonProperty("x_mitre_platforms")]
        public IEnumerable<string> MitrePlatforms { get; set; }
        [JsonProperty("x_mitre_shortname")]
        public string MitreShortName { get; set; }
        [JsonProperty("tactic_refs")]
        public IEnumerable<string> MitreTacticsRefs { get; set; }
        [JsonProperty("x_mitre_version")]
        public string MitreVersion { get; set; }
    }
}
