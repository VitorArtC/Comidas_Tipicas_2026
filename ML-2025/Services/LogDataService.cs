using Microsoft.EntityFrameworkCore;
using ML_2025.Data;
using ML_2025.Entidades;
using ML_2025.Services.Interfaces;

namespace ML_2025.Services
{
    public class LogDataService : ILogDataService
    {
        private readonly AppDbContext _context;

        public LogDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LogData>> GetAllAsync()
        {
            return await _context.logDatas.ToListAsync();
        }

        public async Task<LogData?> GetByIdAsync(Guid id)
        {
            return await _context.logDatas.FindAsync(id);
        }

        public async Task CreateAsync(LogData entity)
        {
            await _context.logDatas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LogData entity)
        {
            _context.logDatas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.logDatas.FindAsync(id);
            if (entity != null)
            {
                _context.logDatas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
