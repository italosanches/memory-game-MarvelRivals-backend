using MemoryGame.Context;
using MemoryGame.Entityes;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserScore>> GetAsync()
        {
           return await  _context.UsersScore.OrderBy(x => x.Score).ToListAsync();
        }

        public async Task<UserScore> CreateAsync(UserScore userScore)
        {
            try
            {
                await _context.AddAsync(userScore);
                await _context.SaveChangesAsync();
                return userScore;
            }
            catch (Exception ex) 
            {
               throw new Exception($"Erro ao salvar pontuação. {ex.Message}");
            }
        }

    }
}
