using MemoryGame.Context;
using MemoryGame.Entityes;
using MemoryGame.Parameters;
using MemoryGame.Repository;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Service
{
    public class UserScoreService : IUserScoreService
    {
        private readonly IRepository _repository;
        public UserScoreService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserScore> CreateUserScore(UserScore userScore)
        {
            try
            {
               return await _repository.CreateAsync(userScore);
            }
            catch
            {
                throw;            
            }
        }

        public async Task<IEnumerable<UserScore>> GetScoreAsync(ScoreQueryParameters queryParameters)
        {
            var query = await _repository.GetQueryable(query =>
            {
                if (queryParameters.CardsQuantities > 0) 
                {
                    query = query.Where(q => q.CardsQuantity == queryParameters.CardsQuantities);
                }
                return query.OrderBy(q=> q.GameTime).Take(10);
            });
            return await query.ToListAsync(); ;
        }
    }
}
