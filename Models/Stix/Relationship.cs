using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Stix
{
    public class Relationship
    {
        public DateTime? Created { get; set; }
        public string CreatedByRef { get; set; }
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        public string Id { get; set; }
        public DateTime? Modified { get; set; }
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        public string RelationshipType { get; set; }
        public string SourceRef { get; set; }
        public string SpecVersion { get; set; }
        public string TargetRef { get; set; }
        public string Type { get; set; }
    }
}
