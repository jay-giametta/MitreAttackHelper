using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Stix
{
    public class MarkingDefinition
    {
        public DateTime? Created { get; set; }
        public string CreatedByRef { get; set; }
        public MarkingObject Definition { get; set; }
        public string DefinitionType { get; set; }
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        public string Id { get; set; }
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        public string SpecVersion { get; set; }
        public string Type { get; set; }
    }
}
