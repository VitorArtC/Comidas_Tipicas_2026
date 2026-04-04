using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.ML;
using ML_2025.Models;
using ML_2025.Services;

public class IndexModel : PageModel
{
    private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;

    public IndexModel(PredictionEngine<SentimentData, SentimentPrediction> predictionEngine)
    {
        _predictionEngine = predictionEngine;
    }

    [BindProperty]
    public string InputText { get; set; }


    public SentimentPrediction PredictionResult { get; set; }

    public void OnGet()
    {
    }


    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(InputText))
        {
            return Page(); 
        }

        Logs logs = new Logs();
        logs.GenerateLogRequest(InputText);
        var inputData = new SentimentData { Text = InputText };
        PredictionResult = _predictionEngine.Predict(inputData);

        logs.GenerateLogRequestResponse(InputText, PredictionResult.PredictedLabel.ToString());
        return Page();
    }

    public IActionResult OnPostFeedback(string input, string resposta, EnumTipoFeedback.feedback tipo)
    {
        Feedback feedback = new Feedback();
        feedback.GenerateFeedback(input, resposta, tipo);
        
        return RedirectToPage();
    }
}