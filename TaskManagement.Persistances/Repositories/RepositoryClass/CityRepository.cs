using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Interfaces.Repositories;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistances.Contexts;

namespace TaskManagement.Persistances.Repositories.RepositoryClass
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a City
        public void Add(City entity)
        {
            _context.Cities.Add(entity);
        }

        // Add multiple Cities
        public void AddRange(List<City> entities)
        {
            _context.Cities.AddRange(entities);
        }

        // Update a City
        public void Update(City entity)
        {
            _context.Cities.Update(entity);
        }

        // Delete a City
        public void Delete(City entity)
        {
            _context.Cities.Remove(entity);
        }

        // Remove multiple Cities
        public void RemoveRange(IEnumerable<City> entities)
        {
            _context.Cities.RemoveRange(entities);
        }

        // Get all Cities
        public async Task<IReadOnlyList<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        // Get a City by Id
        public async Task<City?> GetByIdAsync(object id)
        {
            return await _context.Cities.FindAsync(id);
        }

        // Get a City by a custom condition (i.e., using LINQ)
        public async Task<City?> GetAsync(Expression<Func<City, bool>> criteria)
        {
            return await _context.Cities.Where(criteria).FirstOrDefaultAsync();
        }

        // Get multiple Cities by custom condition (i.e., using LINQ)
        public async Task<IReadOnlyList<City>> GetManyAsync(Expression<Func<City, bool>> criteria)
        {
            return await _context.Cities.Where(criteria).ToListAsync();
        }

        // Commit changes to the database
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Rollback changes (if necessary)
        public async Task RollbackAsync()
        {
            await _context.Entry(_context).ReloadAsync();
        }

        // Get Cities with pagination (optional)
        public async Task<IReadOnlyList<City>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _context.Cities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
