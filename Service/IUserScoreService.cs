using MemoryGame.Entityes;
using MemoryGame.Parameters;

namespace MemoryGame.Service
{
    public interface IUserScoreService
    {
        public Task<IEnumerable<UserScore>> GetScoreAsync(ScoreQueryParameters scoreQueryParameters);
        public Task<UserScore> CreateUserScore(UserScore userScore);
    }
}
