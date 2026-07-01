using Microsoft.AspNetCore.Mvc.RazorPages;
using ML_2025.DTOs;
using ML_2025.Services.Interfaces;

namespace ML_2025.Pages
{
    public class FeedbacksModel : PageModel
    {
        private readonly IFeedBackDataService _feedBackDataService;

        public FeedbacksModel(IFeedBackDataService feedBackDataService)
        {
            _feedBackDataService = feedBackDataService;
        }

        public List<FeedbackEntry> Feedbacks { get; set; } = new List<FeedbackEntry>();

        public async Task OnGetAsync()
        {
            var dados = await _feedBackDataService.GetAllAsync();

            Feedbacks = dados
                .OrderByDescending(f => f.CreatAt)
                .Select(f => new FeedbackEntry
                {
                    Timestamp = f.CreatAt.ToString("dd/MM/yyyy HH:mm"),
                    Input = f.Input,
                    Tipo = f.Tipo?.ToString() ?? "-"
                })
                .ToList();
        }
    }
}
