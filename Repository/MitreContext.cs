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
        private MitreBundle mitreBundle;
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

            LoadMitreAttackPatterns(mitreBundle.Objects.Where(stix => stix.Type == "attack-pattern"));
            LoadMitreCollections(mitreBundle.Objects.Where(stix => stix.Type == "x-mitre-collection"));
            LoadMitreCoursesOfAction(mitreBundle.Objects.Where(stix => stix.Type == "course-of-action"));
            LoadMitreDataComponents(mitreBundle.Objects.Where(stix => stix.Type == "x-mitre-data-component"));
            LoadMitreDataSources(mitreBundle.Objects.Where(stix => stix.Type == "x-mitre-data-source"));
            LoadMitreIdentities(mitreBundle.Objects.Where(stix => stix.Type == "identity"));
            LoadMitreIntrusionSets(mitreBundle.Objects.Where(stix => stix.Type == "intrusion-set"));
            LoadMitreMalware(mitreBundle.Objects.Where(stix => stix.Type == "malware"));
            LoadMitreMarkingDefinitions(mitreBundle.Objects.Where(stix => stix.Type == "marking-definition"));
            LoadMitreMatrices(mitreBundle.Objects.Where(stix => stix.Type == "x-mitre-matrix"));
            LoadMitreRelationships(mitreBundle.Objects.Where(stix => stix.Type == "relationship"), 
                new string[] { "subtechnique-of", "uses" });
            LoadMitreTactics(mitreBundle.Objects.Where(stix => stix.Type == "x-mitre-tactic"));
            LoadMitreTools(mitreBundle.Objects.Where(stix => stix.Type == "tool"));
        }

        protected void LoadMitreAttackPatterns(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreAttackPatterns = bundle.Select(stix => new MitreAttackPattern()
            {
                Aliases = stix.Aliases,
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                KillChainPhases = stix.KillChainPhases,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreContributers = stix.MitreContributers,
                MitreDetection = stix.MitreDetection,
                MitreDataSources = stix.MitreDataSources,
                MitreDefenseByPassed = stix.MitreDefenseByPassed,
                MitreDomains = stix.MitreDomains,
                MitreIsSubTechnique = stix.MitreIsSubTechnique,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitrePlatforms = stix.MitrePlatforms,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                SpecVersion = stix.SpecVersion,
                SourceRef = stix.SourceRef,
                TargetRef = stix.TargetRef,
                Type = stix.Type,
            });
        }

        protected void LoadMitreCollections(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreCollections = bundle.Select(stix => new MitreCollection()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreContents = stix.MitreContents,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                SourceRef = stix.SourceRef,
                SpecVersion = stix.SpecVersion,
                TargetRef = stix.TargetRef,
                Type = stix.Type
            });
        }

        protected void LoadMitreCoursesOfAction(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreCoursesOfAction = bundle.Select(stix => new MitreCourseOfAction()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreDeprecated = stix.MitreDeprecated,
                MitreDomains = stix.MitreDomains,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                SourceRef = stix.SourceRef,
                SpecVersion = stix.SpecVersion,
                TargetRef = stix.TargetRef,

                Type = stix.Type
            });
        }

        protected void LoadMitreDataComponents(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreDataComponents = bundle.Select(stix => new MitreDataComponent()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreDataSourceRef = stix.MitreDataSourceRef,
                MitreDomains = stix.MitreDomains,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                Revoked = stix.Revoked,
                SpecVersion = stix.SpecVersion,
                Type = stix.Type,
            });
        }

        protected void LoadMitreDataSources(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreDataSources = bundle.Select(stix => new MitreDataSource()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreDomains = stix.MitreDomains,
                MitreContributers = stix.MitreContributers,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitrePlatforms = stix.MitrePlatforms,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                Revoked = stix.Revoked,
                SpecVersion = stix.SpecVersion,
                Type = stix.Type,
            });
        }

        protected void LoadMitreIdentities(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreIdentities = bundle.Select(stix => new MitreIdentity()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                IdentityClass = stix.IdentityClass,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreDomains = stix.MitreDomains,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                Roles = stix.Roles,
                Sectors = stix.Sectors,
                SpecVersion = stix.SpecVersion,
                SourceRef = stix.SourceRef,
                TargetRef = stix.TargetRef,
                Type = stix.Type
            });
        }

        protected void LoadMitreIntrusionSets(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreIntrusionSets = bundle.Select(stix => new MitreIntrusionSet()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreDeprecated = stix.MitreDeprecated,
                MitreDomains = stix.MitreDomains,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                SourceRef = stix.SourceRef,
                SpecVersion = stix.SpecVersion,
                TargetRef = stix.TargetRef,
                Type = stix.Type,
                Aliases = stix.Aliases,
            });
        }

        protected void LoadMitreMalware(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreMalware = bundle.Select(stix => new MitreMalware()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                IsFamily = stix.IsFamily,
                MitreAliases = stix.MitreAlases,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreContributers = stix.MitreContributers,
                MitreDomains = stix.MitreDomains,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitrePlatforms = stix.MitrePlatforms,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                SourceRef = stix.SourceRef,
                SpecVersion = stix.SpecVersion,
                TargetRef = stix.TargetRef,
                Type = stix.Type
            });
        }

        protected void LoadMitreMarkingDefinitions(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreMarkingDefinitions = bundle.Select(stix => new MitreMarkingDefinition()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Definition = stix.Definition,
                DefinitionType = stix.DefinitionType,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreDomains = stix.MitreDomains,
                Modified = stix.Modified,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                SourceRef = stix.SourceRef,
                SpecVersion = stix.SpecVersion,
                TargetRef = stix.TargetRef,
                Type = stix.Type,
            });
        }

        protected void LoadMitreMatrices(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreMatrices = bundle.Select(stix => new MitreMatrix()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreDomains = stix.MitreDomains,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitreTacticsRefs = stix.MitreTacticsRefs,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                Revoked = stix.Revoked,
                SpecVersion = stix.SpecVersion,
                Type = stix.Type
            });
        }

        protected void LoadMitreRelationships(in IEnumerable<MitreStixGeneric> bundle, IEnumerable<string> types)
        {
            MitreRelationships = bundle
                .Where(relationship => types.Contains(relationship.RelationshipType))
                .Select(stix => new MitreRelationship()
                {
                    Created = stix.Created,
                    CreatedByRef = stix.CreatedByRef,
                    ExternalReferences = stix.ExternalReferences,
                    Id = stix.Id,
                    MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                    MitreDeprecated = stix.MitreDeprecated,
                    MitreDomains = stix.MitreDomains,
                    MitreModifiedByRef = stix.MitreModifiedByRef,
                    MitreVersion = stix.MitreVersion,
                    Modified = stix.Modified,
                    ObjectMarkingRefs = stix.ObjectMarkingRefs,
                    RelationshipType = stix.RelationshipType,
                    Revoked = stix.Revoked,
                    SourceRef = stix.SourceRef,
                    SpecVersion = stix.SpecVersion,
                    TargetRef = stix.TargetRef,
                    Type = stix.Type
                });
        }

        protected void LoadMitreTactics(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreTactics = bundle.Select(stix => new MitreTactic()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAttackSpecVersion = stix.MitreAttackSpecVersion,
                MitreContributers = stix.MitreContributers,
                MitreDomains = stix.MitreDomains,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitreVersion = stix.MitreVersion,
                MitreShortName = stix.MitreShortName,
                MitreTacticsRefs = stix.MitreTacticsRefs,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                Revoked = stix.Revoked,
                SpecVersion = stix.SpecVersion,
                Type = stix.Type,
            });
        }

        protected void LoadMitreTools(in IEnumerable<MitreStixGeneric> bundle)
        {
            MitreTools = bundle.Select(stix => new MitreTool()
            {
                Created = stix.Created,
                CreatedByRef = stix.CreatedByRef,
                Description = stix.Description,
                ExternalReferences = stix.ExternalReferences,
                Id = stix.Id,
                MitreAliases = stix.MitrePlatforms,
                MitreContributers = stix.MitreContributers,
                MitreDeprecated = stix.MitreDeprecated,
                MitreDomains = stix.MitreDomains,
                MitreModifiedByRef = stix.MitreModifiedByRef,
                MitrePlatforms = stix.MitrePlatforms,
                MitreVersion = stix.MitreVersion,
                Modified = stix.Modified,
                Name = stix.Name,
                ObjectMarkingRefs = stix.ObjectMarkingRefs,
                RelationshipType = stix.RelationshipType,
                Revoked = stix.Revoked,
                SourceRef = stix.SourceRef,
                SpecVersion = stix.SpecVersion,
                TargetRef = stix.TargetRef,
                Type = stix.Type,
            });
        }
    }
}
