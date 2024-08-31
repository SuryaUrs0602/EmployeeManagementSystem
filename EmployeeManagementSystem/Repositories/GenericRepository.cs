using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly EmployeeManagementDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(EmployeeManagementDbContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task Add(T obj)
        {
            _dbSet.Add(obj);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Added new {obj}");
        }

        public async Task Delete(object ID)
        {
            var data = await _dbSet.FindAsync(ID);

            if (data != null)
            {
                _dbSet.Remove(data);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Deleted {data}");
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            _logger.LogInformation("Fetched all datas");
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByID(object ID)
        {
            _logger.LogInformation("Fetched the data by ID");
            return await _dbSet.FindAsync(ID);
        }

        public async Task Update(object ID, T obj)
        {
            var data = await _dbSet.FindAsync(ID);
            if (data != null)
            {
                //_dbSet.Entry(data).CurrentValues.SetValues(obj);
                //await _context.SaveChangesAsync();

                _context.Entry(data).State = EntityState.Detached;
                var keyProperty = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
                if (keyProperty != null)
                {
                    keyProperty.PropertyInfo.SetValue(obj, ID);
                    _context.Attach(obj);
                    _context.Entry(obj).State = EntityState.Modified;
                    _context.Entry(obj).Property(keyProperty.Name).IsModified = false;
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Updated {obj}");
                }

            }
        }
    }
}
