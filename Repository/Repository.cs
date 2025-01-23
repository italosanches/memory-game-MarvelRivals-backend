using MemoryGame.Context;
using MemoryGame.Entityes;
using MemoryGame.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace MemoryGame.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserScore>> GetAsyncQueryable(IQueryable<UserScore> queryable)
        {
            return await queryable.ToListAsync();
        }

        public async Task<IQueryable<UserScore>> GetQueryable(Func<IQueryable<UserScore>, IQueryable<UserScore>> queryBuilder = null)
        {
            IQueryable<UserScore> queryUserScore = _context.UsersScore;
            if (queryBuilder != null)
            {
                queryUserScore = queryBuilder(queryUserScore);
            }
            return queryUserScore;

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
