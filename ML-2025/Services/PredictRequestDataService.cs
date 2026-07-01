using Microsoft.EntityFrameworkCore;
using ML_2025.Data;
using ML_2025.Entidades;
using ML_2025.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ML_2025.Services
{
    public class PredictRequestDataService : IPredictRequestDataService
    {
        private readonly AppDbContext _context;

        public PredictRequestDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PredictRequestData>> GetAllAsync()
        {
            return await _context.PredictRequests.ToListAsync();
        }

        public async Task<PredictRequestData?> GetByIdAsync(Guid id)
        {
            return await _context.PredictRequests.FindAsync(id);
        }

        public async Task CreateAsync(PredictRequestData entity)
        {
            await _context.PredictRequests.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PredictRequestData entity)
        {
            _context.PredictRequests.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.PredictRequests.FindAsync(id);
            if (entity != null)
            {
                _context.PredictRequests.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
