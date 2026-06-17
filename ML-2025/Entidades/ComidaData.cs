using ML_2025.Tables;
using System.ComponentModel.DataAnnotations;

namespace ML_2025.Entidades
{
    public class ComidaData : Base
    {
        public String Prato { get ; set; }
        public String Regiao { get; set; }
        public bool Label { get; set; }
    }
}
