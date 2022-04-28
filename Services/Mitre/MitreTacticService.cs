using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreTacticService
    {
        protected readonly IServiceProvider services;
        public MitreTacticService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreTactic> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreTactics;
        }
    }
}
