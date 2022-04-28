using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using MitreAttackHelper.Models.Mitre;
using MitreAttackHelper.Services.Mitre;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MitreAttackHelper.Pages.Matrix
{
    public class IndexModel : PageModel
    {
        protected readonly IServiceProvider services;
        public MitreMatrix Matrix { get; private set; }
        public IEnumerable<(MitreTactic Tactic, IEnumerable<(MitreAttackPattern AttackPattern, string ParentId)> AttackPatterns)> CombinedTacticData { get; set; }
        public List<string> ParentIds { get; private set; }

        public IndexModel(IServiceProvider services)
        {
            this.services = services;
            ParentIds = new();
        }
        public IActionResult OnGet()
        {
            try
            {
                LoadMatrixData();
                LoadCombinedTacticsData(Matrix);
            }
            catch (InvalidOperationException)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return Page();
        }

        protected void LoadMatrixData()
        {
            MitreMatrixService mitreMatrixService = services.GetRequiredService<MitreMatrixService>();
            Matrix = mitreMatrixService.Get().First();
        }

        protected void LoadCombinedTacticsData(MitreMatrix matrix)
        {
            MitreTacticService mitreTacticService = services.GetRequiredService<MitreTacticService>();
            MitreAttackPatternService mitreAttackPatternService = services.GetRequiredService<MitreAttackPatternService>();

            CombinedTacticData = mitreTacticService.Get()
                .Where(tactic => matrix.MitreTacticsRefs.Contains(tactic.Id))
                .OrderBy(tactic => Array.IndexOf(matrix.MitreTacticsRefs.ToArray(), tactic.Id))
                .Select(tactic => new
                {
                    tactic,
                    attackPatterns = mitreAttackPatternService.Get()
                    .Where(attackPattern => attackPattern.KillChainPhases.Any(phase => phase.PhaseName == tactic.MitreShortName))
                })
                .Select(combined =>
                (combined.tactic,
                combined.attackPatterns
                .Select(attackPattern => (attackPattern, GetParentTechnique(attackPattern)))
                .OrderBy(combined => combined.Item2)
                .ThenBy(combined => (combined.attackPattern.Id == combined.Item2 ? 0 : 1))
                .ThenBy(combined => combined.attackPattern.Name)
                .GroupBy(combined => combined.Item2)
                .OrderBy(group => group.First().attackPattern.Name)
                .SelectMany(group => group)
                .AsEnumerable()));
        }
         
        public string GetParentTechnique(MitreAttackPattern attackPattern)
        {
            if (attackPattern.MitreIsSubTechnique == true)
            {
                MitreRelationshipService mitreRelationshipService = services.GetRequiredService<MitreRelationshipService>();
                string parentId = mitreRelationshipService.GetParentTechnique(attackPattern.Id);
                ParentIds.Add(parentId);
                return parentId;
            }
            return attackPattern.Id;
        }
    }
}
