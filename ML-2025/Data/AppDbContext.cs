using Microsoft.EntityFrameworkCore;
using ML_2025.Entidades;
using ML_2025.Tables;
using System.Runtime.CompilerServices;

namespace ML_2025.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TreinamentoData> Treinamentos { get; set; }
        public DbSet<SentimentPredictionData> SentimentPredictions { get; set; }
        public DbSet<PredictRequestData> PredictRequests { get; set; }
        public DbSet<FeedbackData> FeedBacks { get; set; }
        public DbSet<PredictionResponseData> PredictionResponses { get; set; }
        public DbSet<ComidaData> comidaDatas { get; set; }
        public DbSet<LogData> logDatas { get; set; }

        



        
    }
    
    
}
