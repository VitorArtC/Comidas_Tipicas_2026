using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ML_2025.Tables
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime CreatAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; }

        public bool Ativo { get; internal set; } = true;

        private bool Ativo2 { get; set; } = true;
        internal bool Ativo3 { get; set; } = true;
        protected bool Ativo4 { get; set; } = true;



        
        





    }
}
