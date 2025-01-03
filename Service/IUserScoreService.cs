using MemoryGame.Entityes;

namespace MemoryGame.Service
{
    public interface IUserScoreService
    {
        public Task<IEnumerable<UserScore>> GetScoreAsync();
        public Task<UserScore> CreateUserScore(UserScore userScore);
    }
}
