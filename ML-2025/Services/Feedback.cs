using ML_2025.Models;
using ML_2025.Services.Interfaces;
using ML_2025.Tables;

namespace ML_2025.Services
{
    public class Feedback
    {
        private readonly IFeedBackDataService _feedBackDataService;

        public Feedback(IFeedBackDataService feedBackDataService)
        {
            _feedBackDataService = feedBackDataService;
        }

        public async Task GenerateFeedbackAsync(string input, EnumTipoFeedback tipoFeedback)
        {
            var entity = new FeedbackData
            {
                Input = input,
                Tipo = tipoFeedback,
                CreatAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            await _feedBackDataService.CreateAsync(entity);
        }
    }
}