using Microsoft.AspNetCore.Mvc.RazorPages;
using ML_2025.DTOs;
using ML_2025.Services.Interfaces;

namespace ML_2025.Pages
{
    public class LogsModel : PageModel
    {
        private readonly ILogDataService _logDataService;

        public LogsModel(ILogDataService logDataService)
        {
            _logDataService = logDataService;
        }

        public List<LogEntry> LogEntries { get; set; } = new List<LogEntry>();

        public async Task OnGetAsync()
        {
            var dados = await _logDataService.GetAllAsync();

            LogEntries = dados
                .OrderByDescending(l => l.CreatAt)
                .Select(l => new LogEntry
                {
                    Timestamp = l.CreatAt.ToString("dd/MM/yyyy HH:mm:ss"),
                    Input = l.Input ?? "-",
                    Result = $"{(l.Result ? "Comida Típica" : "Não Identificado")} ({l.TimeResponse:F1} ms)"
                })
                .ToList();
        }
    }
}
