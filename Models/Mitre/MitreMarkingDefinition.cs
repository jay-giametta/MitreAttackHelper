using MitreAttackHelper.Models.Stix;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreMarkingDefinition : MarkingDefinition
    {
        public string MitreAttackSpecVersion { get; set; }
        public IEnumerable<string> MitreDomains { get; set; }
    }
}
