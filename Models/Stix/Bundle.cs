using MitreAttackHelper.Models.Stix.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Models.Stix
{
    public class Bundle : IStixObject
    {
        [JsonProperty("created")]
        public DateTime? Created { get; set; }
        [JsonProperty("created_by_ref")]
        public string CreatedByRef { get; set; }
        [JsonProperty("external_references")]
        public IEnumerable<ExternalReference> ExternalReferences { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }
        [JsonProperty("objects")]
        public IEnumerable<StixGeneric> Objects { get; set; }
        [JsonProperty("object_marking_refs")]
        public IEnumerable<string> ObjectMarkingRefs { get; set; }
        [JsonProperty("revoked")]
        public bool? Revoked { get; set; }
        [JsonProperty("spec_version")]
        public string SpecVersion { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
