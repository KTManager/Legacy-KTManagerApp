namespace KillTeam.Domain.Rules.Models.Contracts
{
    public interface ITactic : IIdentifiable<string>, INamed, IDescribed
    {
        string SpecialistId { get; set; }
        string ModelProfileId { get; set; }
        int PhaseId { get; set; }
        
        bool IsAura { get; set; }
        bool IsForCommandersOnly { get; set; }
        int Level { get; set; }
        int Cost { get; set; }
    }
}
