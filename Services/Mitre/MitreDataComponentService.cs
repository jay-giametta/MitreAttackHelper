using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreDataComponentService
    {
        protected readonly IServiceProvider services;
        public MitreDataComponentService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreDataComponent> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreDataComponents;
        }
    }
}
