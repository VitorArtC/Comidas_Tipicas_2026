using Microsoft.EntityFrameworkCore;
using ML_2025.Data;
using ML_2025.Entidades;
using ML_2025.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ML_2025.Services
{
    public class TreinamentoDataService : ITreinamentoDataService
    {
        private readonly AppDbContext _context;

        public TreinamentoDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TreinamentoData>> GetAllAsync()
        {
            return await _context.Treinamentos.ToListAsync();
        }

        public async Task<TreinamentoData?> GetByIdAsync(Guid id)
        {
            return await _context.Treinamentos.FindAsync(id);
        }

        public async Task CreateAsync(TreinamentoData entity)
        {
            await _context.Treinamentos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TreinamentoData entity)
        {
            _context.Treinamentos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Treinamentos.FindAsync(id);
            if (entity != null)
            {
                _context.Treinamentos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
