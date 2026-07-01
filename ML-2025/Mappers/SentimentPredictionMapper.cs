using ML_2025.DTOs;
using ML_2025.Entidades;

namespace ML_2025.Mappers
{
    public static class SentimentPredictionMapper
    {
        public static SentimentPredictionDTO ToDTO(this SentimentPredictionData entity)
        {
            if (entity == null) return null;
            return new SentimentPredictionDTO
            {
                Id = entity.Id,
                CreatAt = entity.CreatAt,
                UpdateAt = entity.UpdateAt,
                PredictedLabel = entity.PredictedLabel,
                Probability = entity.Probability,
                Score = entity.Score
            };
        }

        public static SentimentPredictionData ToEntity(this SentimentPredictionDTO dto)
        {
            if (dto == null) return null;
            return new SentimentPredictionData
            {
                Id = dto.Id,
                CreatAt = dto.CreatAt,
                UpdateAt = dto.UpdateAt,
                PredictedLabel = dto.PredictedLabel,
                Probability = dto.Probability,
                Score = dto.Score
            };
        }
    }
}
