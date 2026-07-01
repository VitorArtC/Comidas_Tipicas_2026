using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.ML;
using ML_2025.Entidades;
using ML_2025.Models;
using ML_2025.Services;
using ML_2025.Services.Interfaces;
using System.Diagnostics;

public class IndexModel : PageModel
{
    private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;
    private readonly Feedback _feedbackService;
    private readonly Logs _logsService;
    private readonly IPredictRequestDataService _predictRequestDataService;

    public IndexModel(
        PredictionEngine<SentimentData, SentimentPrediction> predictionEngine,
        Feedback feedbackService,
        Logs logsService,
        IPredictRequestDataService predictRequestDataService)
    {
        _predictionEngine = predictionEngine;
        _feedbackService = feedbackService;
        _logsService = logsService;
        _predictRequestDataService = predictRequestDataService;
    }

    [BindProperty]
    public string InputText { get; set; }

    public SentimentPrediction PredictionResult { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(InputText?.Trim()))
            return Page();

        // Salvar requisição no banco
        await _predictRequestDataService.CreateAsync(new PredictRequestData
        {
            Text = InputText,
            CreatAt = DateTime.Now,
            UpdateAt = DateTime.Now
        });

        // Medir tempo de predição
        var sw = Stopwatch.StartNew();
        var inputData = new SentimentData { Text = InputText };
        PredictionResult = _predictionEngine.Predict(inputData);
        sw.Stop();

        if (PredictionResult.Probability < 0.85f)
            PredictionResult.PredictedLabel = false;

        // Salvar log no banco
        await _logsService.GenerateLogAsync(
            input: InputText,
            result: PredictionResult.PredictedLabel,
            timeResponseMs: sw.Elapsed.TotalMilliseconds);

        return Page();
    }

    public async Task<IActionResult> OnPostFeedbackAsync(string input, EnumTipoFeedback tipo)
    {
        await _feedbackService.GenerateFeedbackAsync(input, tipo);
        return RedirectToPage();
    }
}