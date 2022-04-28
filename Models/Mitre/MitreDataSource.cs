using MitreAttackHelper.Models.Stix;
using MitreAttackHelper.Models.Stix.Interfaces;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Mitre
{
    public class MitreDataSource : IStixObject
    {
        public DateTime? Created { get; set; }
        public string CreatedByRef { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        public string Id { get; set; }
        public string MitreAttackSpecVersion { get; set; }
        public IEnumerable<string> MitreContributers { get; set; }
        public IEnumerable<string> MitreDomains { get; set; }
        public string MitreModifiedByRef { get; set; }
        public IEnumerable<string> MitrePlatforms { get; set; }
        public string MitreVersion { get; set; }
        public DateTime? Modified { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        public bool? Revoked { get; set; }
        public string SpecVersion { get; set; }
        public string Type { get; set; }
    }
}
