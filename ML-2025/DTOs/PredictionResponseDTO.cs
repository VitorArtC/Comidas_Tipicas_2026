using ML_2025.Tables;
using System.ComponentModel.DataAnnotations;

namespace ML_2025.DTOs
{
    public class PredictionResponseDTO : Base
    {
        public bool Prediction { get; set; }

        public float Score { get; set; }

        public string Sentiment => Prediction ? "Positivo " : "Negativo ";
        public bool IsPositive => Prediction;
    }
}
