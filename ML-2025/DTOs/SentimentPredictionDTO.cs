using ML_2025.Tables;
using System.ComponentModel.DataAnnotations;

namespace ML_2025.DTOs
{
    public class SentimentPredictionDTO : Base
    {
        public bool PredictedLabel { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}
