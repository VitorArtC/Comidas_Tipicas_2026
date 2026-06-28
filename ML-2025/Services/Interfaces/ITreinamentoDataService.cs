using ML_2025.Entidades;

namespace ML_2025.Services.Interfaces
{
    public interface ITreinamentoDataService
    {
        Task<List<TreinamentoData>> GetAllAsync();
        Task<TreinamentoData?> GetByIdAsync(Guid id);
        Task CreateAsync(TreinamentoData entity);
        Task UpdateAsync(TreinamentoData entity);
        Task DeleteAsync(Guid id);
    }
}
