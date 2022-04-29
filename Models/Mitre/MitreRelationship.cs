using MitreAttackHelper.Models.Stix;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreRelationship : Relationship
    {
        public string MitreAttackSpecVersion { get; set; }
        public IEnumerable<string> MitreDomains { get; set; }
        public string MitreModifiedByRef { get; set; }
        public string MitreVersion { get; set; }
    }
}
