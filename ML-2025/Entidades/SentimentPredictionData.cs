using ML_2025.Tables;
using System.ComponentModel.DataAnnotations;

namespace ML_2025.Entidades;

public class SentimentPredictionData : Base
{
    [Required]
    public bool PredictedLabel { get; set; }
    
    [Required]
    public float Probability { get; set; }
    
    [Required]
    public float Score { get; set; }
}