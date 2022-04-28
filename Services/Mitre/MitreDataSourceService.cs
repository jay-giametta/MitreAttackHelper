using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreDataSourceService
    {
        protected readonly IServiceProvider services;
        public MitreDataSourceService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreDataSource> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreDataSources;
        }
    }
}
