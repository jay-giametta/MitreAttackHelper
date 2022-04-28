using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreIdentityService
    {
        protected readonly IServiceProvider services;
        public MitreIdentityService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreIdentity> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreIdentities;
        }
    }
}
