using Microsoft.EntityFrameworkCore;
using ML_2025.Data;
using ML_2025.Tables;
using ML_2025.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ML_2025.Services
{
    public class FeedBackDataService : IFeedBackDataService
    {
        private readonly AppDbContext _context;

        public FeedBackDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FeedbackData>> GetAllAsync()
        {
            return await _context.FeedBacks.ToListAsync();
        }

        public async Task<FeedbackData?> GetByIdAsync(Guid id)
        {
            return await _context.FeedBacks.FindAsync(id);
        }

        public async Task CreateAsync(FeedbackData entity)
        {
            await _context.FeedBacks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeedbackData entity)
        {
            _context.FeedBacks.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.FeedBacks.FindAsync(id);
            if (entity != null)
            {
                _context.FeedBacks.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
