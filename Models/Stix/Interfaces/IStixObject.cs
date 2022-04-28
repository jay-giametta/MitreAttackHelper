using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Stix.Interfaces
{
    public interface IStixObject
    {
        public DateTime? Created { get; set; }
        public string CreatedByRef { get; set; }
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        public string Id { get; set; }
        public DateTime? Modified { get; set; }
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        public bool? Revoked { get; set; }
        public string SpecVersion { get; set; }
        public string Type { get; set; }
    }
}
