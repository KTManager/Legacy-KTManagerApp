namespace KillTeam.Domain.Rules.Models.Contracts
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; set; }
    }
}
