using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Services.Mitre;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MitreAttackHelper.Pages.Modal
{
    public class IntrusionSetMatchModel : PageModel
    {
        protected IServiceProvider services;
        protected Dictionary<string, int> sets;
        public IEnumerable<(string Id, string Name, string Description, int Count)> CombinedIntrusionSetData;

        public IntrusionSetMatchModel(IServiceProvider services)
        {
            this.services = services;
            CombinedIntrusionSetData = new List<(string Id, string Name, string Description, int Count)>();
        }

        public IActionResult OnGet()
        {
            LoadParameters(Request?.Query);
            LoadIntrusionSetData(sets);
            return Page();
        }

        protected void LoadParameters(IQueryCollection query)
        {
            try
            {
                sets = JsonConvert.DeserializeObject<Dictionary<string, int>>(query?["sets"].FirstOrDefault());
            }
            catch (Exception)
            {
                //No Results Found
            }
        }

        protected void LoadIntrusionSetData(Dictionary<string, int> setData)
        {
            MitreIntrusionSetService mitreIntrusionSetService = services.GetRequiredService<MitreIntrusionSetService>();

            CombinedIntrusionSetData = setData?
                .Select(set => new { intrusionSet = mitreIntrusionSetService.Get(set.Key), set.Value })
                .Select(combined => (combined.intrusionSet.Id, combined.intrusionSet.Name, combined.intrusionSet.Description, combined.Value))
                ?? CombinedIntrusionSetData;
        }
    }
}
