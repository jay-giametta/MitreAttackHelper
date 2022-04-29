using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Stix
{
    public class Identity
    {
        public DateTime? Created { get; set; }
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        public string Id { get; set; }
        public string IdentityClass { get; set; }
        public DateTime? Modified { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<string> Sectors { get; set; }
        public string SpecVersion { get; set; }
        public string Type { get; set; }

    }
}
