using ML_2025.Tables;
using System.ComponentModel.DataAnnotations;

namespace ML_2025.Entidades
{
    public class PredictRequestData : Base
    {
        [Required]
        public string Text { get; set; }
       
    }
}
