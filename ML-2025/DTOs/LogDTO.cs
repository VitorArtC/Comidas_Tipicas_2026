using ML_2025.Tables;
namespace ML_2025.DTOs

{
    public class LogDTO : Base
    {
        public string? Input { get; set; }
        public bool Result { get; set; }
        public double TimeResponse { get; set; }
    }
}
