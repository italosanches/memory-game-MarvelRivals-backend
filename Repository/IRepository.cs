using MemoryGame.Entityes;

namespace MemoryGame.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<UserScore>> GetAsync();
        public Task<UserScore> CreateAsync(UserScore userScore);
    }
}
