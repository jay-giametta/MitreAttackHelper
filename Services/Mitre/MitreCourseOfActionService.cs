using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Repository;
using System;
using System.Collections.Generic;

namespace MitreAttackHelper.Services.Mitre
{
    public class MitreCourseOfActionService
    {
        protected readonly IServiceProvider services;
        public MitreCourseOfActionService(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<MitreCourseOfAction> Get()
        {
            MitreContext mitreContext = services.GetRequiredService<MitreContext>();
            return mitreContext.MitreCoursesOfAction;
        }
    }
}
