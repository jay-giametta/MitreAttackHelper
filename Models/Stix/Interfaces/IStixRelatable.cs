
namespace MitreAttackHelper.Models.Stix.Interfaces
{
    public interface IStixRelatable
    {
        public string RelationshipType { get; set; }
        public string SourceRef { get; set; }
        public string TargetRef { get; set; }
    }
}
