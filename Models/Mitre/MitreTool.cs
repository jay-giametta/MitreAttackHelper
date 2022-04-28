using MitreAttackHelper.Models.Stix;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreTool : Tool
    {
        public IEnumerable<string> MitreAliases { get; set; }
        public IEnumerable<string> MitreContributers { get; set; }
        public bool? MitreDeprecated { get; set; }
        public IEnumerable<string> MitreDomains { get; set; }
        public string MitreModifiedByRef { get; set; }
        public IEnumerable<string> MitrePlatforms { get; set; }
        public string MitreVersion { get; set; }
    }
}
