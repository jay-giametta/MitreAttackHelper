using MitreAttackHelper.Models.Mitre;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MitreAttackHelper.Repository
{
    public class MitreContext
    {
        protected readonly MitreBundle mitreBundle;
        public IEnumerable<MitreAttackPattern> MitreAttackPatterns { get; private set; }
        public IEnumerable<MitreCollection> MitreCollections { get; private set; }
        public IEnumerable<MitreCourseOfAction> MitreCoursesOfAction { get; private set; }
        public IEnumerable<MitreDataComponent> MitreDataComponents { get; private set; }
        public IEnumerable<MitreDataSource> MitreDataSources { get; private set; }
        public IEnumerable<MitreIdentity> MitreIdentities { get; private set; }
        public IEnumerable<MitreIntrusionSet> MitreIntrusionSets { get; private set; }
        public IEnumerable<MitreMalware> MitreMalware { get; private set; }
        public IEnumerable<MitreMarkingDefinition> MitreMarkingDefinitions { get; private set; }
        public IEnumerable<MitreMatrix> MitreMatrices { get; private set; }
        public IEnumerable<MitreRelationship> MitreRelationships { get; private set; }
        public IEnumerable<MitreTactic> MitreTactics { get; private set; }
        public IEnumerable<MitreTool> MitreTools { get; private set; }


        public MitreContext(string url = null, string jsonFile = "App_Data/enterprise-attack.json")
        {
            try
            {
                mitreBundle = JsonConvert.DeserializeObject<MitreBundle>(new WebClient().DownloadString(url));
            }
            catch(Exception)
            {
                mitreBundle = JsonConvert.DeserializeObject<MitreBundle>(File.ReadAllText(jsonFile));
            }

            LoadMitreAttackPatterns(mitreBundle.Objects.Where(generic => generic.Type == "attack-pattern"));
            LoadMitreCollections(mitreBundle.Objects.Where(generic => generic.Type == "x-mitre-collection"));
            LoadMitreCoursesOfAction(mitreBundle.Objects.Where(generic => generic.Type == "course-of-action"));
            LoadMitreDataComponents(mitreBundle.Objects.Where(generic => generic.Type == "x-mitre-data-component"));
            LoadMitreDataSources(mitreBundle.Objects.Where(generic => generic.Type == "x-mitre-data-source"));
            LoadMitreIdentities(mitreBundle.Objects.Where(generic => generic.Type == "identity"));
            LoadMitreIntrusionSets(mitreBundle.Objects.Where(generic => generic.Type == "intrusion-set"));
            LoadMitreMalware(mitreBundle.Objects.Where(generic => generic.Type == "malware"));
            LoadMitreMarkingDefinitions(mitreBundle.Objects.Where(generic => generic.Type == "marking-definition"));
            LoadMitreMatrices(mitreBundle.Objects.Where(generic => generic.Type == "x-mitre-matrix"));
            LoadMitreRelationships(mitreBundle.Objects.Where(generic => generic.Type == "relationship"), 
                new string[] { "subtechnique-of", "uses" });
            LoadMitreTactics(mitreBundle.Objects.Where(generic => generic.Type == "x-mitre-tactic"));
            LoadMitreTools(mitreBundle.Objects.Where(generic => generic.Type == "tool"));
        }

        protected void LoadMitreAttackPatterns(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreAttackPatterns = bundle.Select(generic => new MitreAttackPattern()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                KillChainPhases = generic.KillChainPhases,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreContributers = generic.MitreContributers,
                MitreDetection = generic.MitreDetection,
                MitreDataSources = generic.MitreDataSources,
                MitreDefenseByPassed = generic.MitreDefenseByPassed,
                MitreDomains = generic.MitreDomains,
                MitreIsSubTechnique = generic.MitreIsSubTechnique,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitrePlatforms = generic.MitrePlatforms,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type,
            });
        }

        protected void LoadMitreCollections(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreCollections = bundle.Select(generic => new MitreCollection()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                Id = generic.Id,
                MitreContents = generic.MitreContents,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type
            });
        }

        protected void LoadMitreCoursesOfAction(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreCoursesOfAction = bundle.Select(generic => new MitreCourseOfAction()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDeprecated = generic.MitreDeprecated,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type
            });
        }

        protected void LoadMitreDataComponents(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreDataComponents = bundle.Select(generic => new MitreDataComponent()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDataSourceRef = generic.MitreDataSourceRef,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type,
            });
        }

        protected void LoadMitreDataSources(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreDataSources = bundle.Select(generic => new MitreDataSource()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitrePlatforms = generic.MitrePlatforms,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type,
            });
        }

        protected void LoadMitreIdentities(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreIdentities = bundle.Select(generic => new MitreIdentity()
            {
                Created = generic.Created,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                IdentityClass = generic.IdentityClass,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDomains = generic.MitreDomains,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                Roles = generic.Roles,
                Sectors = generic.Sectors,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type
            });
        }

        protected void LoadMitreIntrusionSets(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreIntrusionSets = bundle.Select(generic => new MitreIntrusionSet()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type,
                Aliases = generic.Aliases,
            });
        }

        protected void LoadMitreMalware(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreMalware = bundle.Select(generic => new MitreMalware()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                IsFamily = generic.IsFamily,
                MitreAliases = generic.MitreAlases,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitrePlatforms = generic.MitrePlatforms,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type
            });
        }

        protected void LoadMitreMarkingDefinitions(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreMarkingDefinitions = bundle.Select(generic => new MitreMarkingDefinition()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Definition = generic.Definition,
                DefinitionType = generic.DefinitionType,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDomains = generic.MitreDomains,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type,
            });
        }

        protected void LoadMitreMatrices(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreMatrices = bundle.Select(generic => new MitreMatrix()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitreTacticsRefs = generic.MitreTacticsRefs,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type
            });
        }

        protected void LoadMitreRelationships(in IEnumerable<MitreStixGeneric> bundle, IEnumerable<string> types)
        {
            MitreRelationships = bundle
                .Where(relationship => types.Contains(relationship.RelationshipType))
                .Select(generic => new MitreRelationship()
                {
                    Created = generic.Created,
                    CreatedByRef = generic.CreatedByRef,
                    ExternalReferences = generic.ExternalReferences,
                    Id = generic.Id,
                    MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                    MitreDomains = generic.MitreDomains,
                    MitreModifiedByRef = generic.MitreModifiedByRef,
                    MitreVersion = generic.MitreVersion,
                    Modified = generic.Modified,
                    ObjectMarkingRefs = generic.ObjectMarkingRefs,
                    RelationshipType = generic.RelationshipType,
                    SourceRef = generic.SourceRef,
                    SpecVersion = generic.SpecVersion,
                    TargetRef = generic.TargetRef,
                    Type = generic.Type
                });
        }

        protected void LoadMitreTactics(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreTactics = bundle.Select(generic => new MitreTactic()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAttackSpecVersion = generic.MitreAttackSpecVersion,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitreVersion = generic.MitreVersion,
                MitreShortName = generic.MitreShortName,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type,
            });
        }

        protected void LoadMitreTools(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreTools = bundle.Select(generic => new MitreTool()
            {
                Created = generic.Created,
                CreatedByRef = generic.CreatedByRef,
                Description = generic.Description,
                ExternalReferences = generic.ExternalReferences,
                Id = generic.Id,
                MitreAliases = generic.MitrePlatforms,
                MitreDomains = generic.MitreDomains,
                MitreModifiedByRef = generic.MitreModifiedByRef,
                MitrePlatforms = generic.MitrePlatforms,
                MitreVersion = generic.MitreVersion,
                Modified = generic.Modified,
                Name = generic.Name,
                ObjectMarkingRefs = generic.ObjectMarkingRefs,
                SpecVersion = generic.SpecVersion,
                Type = generic.Type,
            });
        }
    }
}
