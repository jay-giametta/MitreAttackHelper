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

        public string GetAttackPatternParent(string subId)
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreRelationships
                .FirstOrDefault(relationship => relationship.RelationshipType == "subtechnique-of" 
                && relationship.SourceRef == subId)
                ?.TargetRef ?? subId;
        }

        public IEnumerable<string> GetAttackPatternsUsed(string id)
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreRelationships
                .Where(relationship => relationship.RelationshipType == "uses"
                && relationship.SourceRef == id
                && relationship.TargetRef.StartsWith("attack"))
                .Select(relationship => relationship.TargetRef);
        }
    }
}
