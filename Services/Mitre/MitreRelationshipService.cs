using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreRelationshipService
    {
        protected readonly IServiceProvider services;
        public MitreRelationshipService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreRelationship> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreRelationships;
        }

        public string GetParentTechnique(string subId)
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreRelationships
                .FirstOrDefault(relationship => relationship.RelationshipType == "subtechnique-of" && relationship.SourceRef == subId)
                ?.TargetRef ?? subId;
        }
    }
}
