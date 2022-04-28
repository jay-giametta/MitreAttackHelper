using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreMarkingDefinitionService
    {
        protected readonly IServiceProvider services;
        public MitreMarkingDefinitionService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreMarkingDefinition> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();

            return mitreContext.MitreMarkingDefinitions;
        }
    }
}
