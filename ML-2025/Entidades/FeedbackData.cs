using ML_2025.Models;
using System.ComponentModel.DataAnnotations;

namespace ML_2025.Tables
{
    public class FeedbackData : Base
    {
        [Required]

        public String Input { get ; set; }
        public EnumTipoFeedback? Tipo { get ; set; }
    }
}
