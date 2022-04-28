using MitreAttackHelper.Models.Stix;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreIdentity : Identity
    {
        public string MitreAttackSpecVersion { get; set; }
        public IEnumerable<string> MitreDomains { get; set; }
        public string MitreVersion { get; set; }
    }
}
