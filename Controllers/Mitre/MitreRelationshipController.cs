using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Services.Mitre;
using Newtonsoft.Json;
using System;

namespace MitreAttackHelper.Controllers.Mitre
{
    public class MitreRelationshipController: Controller
    {
        protected readonly IServiceProvider services;
        public MitreRelationshipController(IServiceProvider services)
        {
            this.services = services;
        }

        [HttpGet("API/Mitre/Relationships/Source/{id}/UsesAttackPatterns")]
        public IActionResult GetUsesAttackPatterns(string id)
        {
            MitreRelationshipService mitreRelationshipService = services.GetRequiredService<MitreRelationshipService>();
            return Ok(JsonConvert.SerializeObject(mitreRelationshipService.GetUsesAttackPatterns(id), Formatting.Indented));
        }

        [HttpGet("API/Mitre/Relationships/Target/{id}/UsedByIntrusionSets")]
        public IActionResult GetTargetUsedByIntrusionSets(string id)
        {
            MitreRelationshipService mitreRelationshipService = services.GetRequiredService<MitreRelationshipService>();
            return Ok(JsonConvert.SerializeObject(mitreRelationshipService.GetTargetUsedByIntrusionSets(id), Formatting.Indented));
        }
    }
}
