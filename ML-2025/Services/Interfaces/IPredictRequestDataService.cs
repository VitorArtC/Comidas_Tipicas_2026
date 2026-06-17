using ML_2025.Entidades;
using ML_2025.Models;

namespace ML_2025.Services.Interfaces
{
    public interface IPredictRequestDataService
    {

        public Task<List<PredictRequestData>> GetAllAsync();

        public Task<PredictRequestData?> GetByIdAsync();
        public Task CreateAsync(PredictRequestData entity);

        public Task UpdateAsync(PredictRequestData entity);
        
        public Task DeleteAsync(Guid id);  
    }
}
