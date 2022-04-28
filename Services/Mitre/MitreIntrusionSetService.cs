using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreIntrusionSetService
    {
        protected readonly IServiceProvider services;
        public MitreIntrusionSetService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreIntrusionSet> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreIntrusionSets;
        }
    }
}
