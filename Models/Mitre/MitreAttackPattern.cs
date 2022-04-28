using MitreAttackHelper.Models.Stix;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreAttackPattern : AttackPattern
    {
        public string MitreAttackSpecVersion { get; set; }

        public IEnumerable<string> MitreContributers { get; set; }
        public IEnumerable<string> MitreDataSources { get; set; }
        public IEnumerable<string> MitreDefenseByPassed { get; set; }
        public string MitreDetection { get; set; }
        public IEnumerable<string> MitreDomains { get; set; }
        public bool? MitreIsSubTechnique { get; set; }
        public string MitreModifiedByRef { get; set; }
        public IEnumerable<string> MitrePlatforms { get; set; }
        public string MitreVersion { get; set; }
    }
}
