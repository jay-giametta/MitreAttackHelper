using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreMatrixService
    {
        protected readonly IServiceProvider services;
        public MitreMatrixService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreMatrix> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();

            return mitreContext.MitreMatrices;
        }
    }
}
