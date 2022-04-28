using MitreAttackHelper.Models.Stix.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Stix
{
    public class StixGeneric : IStixObject, IStixRelatable
    {
        [JsonProperty("aliases")]
        public IEnumerable<string> Aliases { get; set; }
        [JsonProperty("created")]
        public DateTime? Created { get; set; }
        [JsonProperty("created_by_ref")]
        public string CreatedByRef { get; set; }
        [JsonProperty("definition")]
        public MarkingObject Definition { get; set; }
        [JsonProperty("definition_type")]
        public string DefinitionType { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("external_references")]
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("identity_class")]
        public string IdentityClass { get; set; }
        [JsonProperty("is_family")]
        public bool? IsFamily { get; set; }
        [JsonProperty("kill_chain_phases")]
        public IEnumerable<KillChainPhase> KillChainPhases { get; set; }
        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("object_marking_refs")]
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        [JsonProperty("relationship_type")]
        public string RelationshipType { get; set; }
        [JsonProperty("revoked")]
        public bool? Revoked { get; set; }
        [JsonProperty("roles")]
        public IEnumerable<string> Roles { get; set; }
        [JsonProperty("sectors")]
        public IEnumerable<string> Sectors { get; set; }
        [JsonProperty("source_ref")]
        public string SourceRef { get; set; }
        [JsonProperty("spec_version")]
        public string SpecVersion { get; set; }
        [JsonProperty("target_ref")]
        public string TargetRef { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
