using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreCollectionService
    {
        protected readonly IServiceProvider services;
        public MitreCollectionService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreCollection> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreCollections;
        }
    }
}
