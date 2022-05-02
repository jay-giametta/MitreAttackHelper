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

        [HttpGet("API/Mitre/Relationships/{id}/AttackPatternsUsed")]
        public IActionResult GetAttackPatternsUsed(string id)
        {
            MitreRelationshipService mitreRelationshipService = services.GetRequiredService<MitreRelationshipService>();
            return Ok(JsonConvert.SerializeObject(mitreRelationshipService.GetAttackPatternsUsed(id)));
        }
    }
}
