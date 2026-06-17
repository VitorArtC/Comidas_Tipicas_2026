using ML_2025.Tables;
using System.ComponentModel.DataAnnotations;

namespace ML_2025.Entidades;

public class TreinamentoData : Base
{
    [Required]
    public string Text { get;  set; }
    [Required]
    public bool Label { get; set; }
}