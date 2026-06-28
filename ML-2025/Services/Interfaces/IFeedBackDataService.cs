using ML_2025.Entidades;
using ML_2025.Tables;

namespace ML_2025.Services.Interfaces
{
    public interface IFeedBackDataService
    {

        public Task<List<FeedbackData>> GetAllAsync();
        public Task<FeedbackData?> GetByIdAsync(Guid id);
        public Task CreateAsync(FeedbackData entity);
        public Task UpdateAsync(FeedbackData entity);
        public Task DeleteAsync(Guid id);
    }
}
