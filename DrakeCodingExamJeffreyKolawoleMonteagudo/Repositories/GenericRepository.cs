using DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DrakeCodingExamJeffreyKolawoleMonteagudo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DrakeCodingExamDbContext _context;

        public GenericRepository(DrakeCodingExamDbContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry<T>> AddAsync(T entity)
        {
            return await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
