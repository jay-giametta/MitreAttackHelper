using MitreAttackHelper.Models.Stix.Interfaces;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Stix
{
    public class Relationship : IStixObject, IStixRelatable
    {
        public DateTime? Created { get; set; }
        public string CreatedByRef { get; set; }
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        public string Id { get; set; }
        public DateTime? Modified { get; set; }
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        public string RelationshipType { get; set; }
        public bool? Revoked { get; set; }
        public string SourceRef { get; set; }
        public string SpecVersion { get; set; }
        public string TargetRef { get; set; }
        public string Type { get; set; }
    }
}
