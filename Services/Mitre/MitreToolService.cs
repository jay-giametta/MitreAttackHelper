using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreToolService
    {
        protected readonly IServiceProvider services;
        public MitreToolService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreTool> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreTools;
        }
    }
}
