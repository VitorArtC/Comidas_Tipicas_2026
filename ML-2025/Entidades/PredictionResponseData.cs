using System.ComponentModel.DataAnnotations;
using ML_2025.Models;
using ML_2025.Tables;

namespace ML_2025.Entidades;

public class PredictionResponseData : Base
{
    [Required]
    public bool Prediction { get; set; }
    
    [Required]
    public float Score { get; set; }

    public string Sentiment => Prediction ? "Positivo " : "Negativo ";
    public bool IsPositive => Prediction;

    
}