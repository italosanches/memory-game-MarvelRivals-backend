using MemoryGame.Context;
using MemoryGame.Entityes;
using MemoryGame.Repository;

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

        public Task<IEnumerable<UserScore>> GetScoreAsync()
        {
            return _repository.GetAsync();
        }
    }
}
