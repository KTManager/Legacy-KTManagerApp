using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KillTeam.Queries.Handlers
{
    public interface IQueryProcessor
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }

    public class QueryProcessor : IQueryProcessor
    {
        public static IQueryProcessor Instance() => _queryProcessor;

        private static readonly IQueryProcessor _queryProcessor = new QueryProcessor();
        
        public async Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var handlerType =
                Assembly
                    .GetAssembly(typeof(TQuery))
                    .DefinedTypes
                    .FirstOrDefault(t => t.ImplementedInterfaces.Contains(typeof(IQueryHandler<TQuery, TResult>)));

            if (handlerType is null)
                throw new InvalidOperationException($"No query handler for Query {typeof(TQuery)} for result {typeof(TResult)}");

            var handler = Activator.CreateInstance(handlerType) as IQueryHandler<TQuery, TResult>;

            return await handler.Execute(query);
        }
    }
}