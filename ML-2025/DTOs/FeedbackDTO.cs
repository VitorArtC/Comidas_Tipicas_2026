using ML_2025.Models;
using ML_2025.Entidades;
using ML_2025.Tables;

namespace ML_2025.DTOs
{
    public class FeedbackDTO: Base
    {
        public String Input { get; set; }

        public EnumTipoFeedback? Tipo { get; set; }
    }
}
