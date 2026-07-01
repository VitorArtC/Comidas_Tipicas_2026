using ML_2025.Entidades;

namespace ML_2025.Services.Interfaces
{
    public interface ILogDataService
    {
        public Task<List<LogData>> GetAllAsync();
        public Task<LogData?> GetByIdAsync(Guid id);
        public Task CreateAsync(LogData entity);
        public Task UpdateAsync(LogData entity);
        public Task DeleteAsync(Guid id);
    }
}
