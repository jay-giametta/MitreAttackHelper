using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreAttackPatternService
    {
        protected readonly IServiceProvider services;
        public MitreAttackPatternService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreAttackPattern> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreAttackPatterns;
        }
    }
}
