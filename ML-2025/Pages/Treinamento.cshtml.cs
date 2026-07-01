using Microsoft.AspNetCore.Mvc.RazorPages;
using ML_2025.DTOs;
using ML_2025.Services.Interfaces;

namespace ML_2025.Pages
{
    public class TreinamentoModel : PageModel
    {
        private readonly ITreinamentoDataService _treinamentoDataService;

        public TreinamentoModel(ITreinamentoDataService treinamentoDataService)
        {
            _treinamentoDataService = treinamentoDataService;
        }

        public List<TreinamentoEntry> DadosTreinamento { get; set; } = new List<TreinamentoEntry>();

        public async Task OnGetAsync()
        {
            var dados = await _treinamentoDataService.GetAllAsync();

            DadosTreinamento = dados
                .Select(t => new TreinamentoEntry
                {
                    Label = t.Label,
                    Text = t.Text
                })
                .ToList();
        }
    }
}
