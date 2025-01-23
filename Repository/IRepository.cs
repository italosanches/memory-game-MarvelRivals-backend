using MemoryGame.Entityes;
using MemoryGame.Parameters;
using System.Linq.Expressions;

namespace MemoryGame.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<UserScore>> GetAsyncQueryable(IQueryable<UserScore> query);
        public Task<IQueryable<UserScore>> GetQueryable(Func<IQueryable<UserScore>, IQueryable<UserScore>> queryBuilder = null);
        public Task<UserScore> CreateAsync(UserScore userScore);
    }
}
