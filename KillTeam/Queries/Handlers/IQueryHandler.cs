using System.Threading.Tasks;

namespace KillTeam.Queries.Handlers
{
    public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery
    {
        Task<TResponse> Execute(TQuery query);
    }
}