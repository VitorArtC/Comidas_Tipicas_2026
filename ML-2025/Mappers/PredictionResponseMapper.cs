using ML_2025.DTOs;
using ML_2025.Entidades;

namespace ML_2025.Mappers
{
    public static class PredictionResponseMapper
    {
        public static PredictionResponseDTO ToDTO(this PredictionResponseData entity)
        {
            if (entity == null) return null;
            return new PredictionResponseDTO
            {
                Id = entity.Id,
                CreatAt = entity.CreatAt,
                UpdateAt = entity.UpdateAt,
                Prediction = entity.Prediction,
                Score = entity.Score
            };
        }

        public static PredictionResponseData ToEntity(this PredictionResponseDTO dto)
        {
            if (dto == null) return null;
            return new PredictionResponseData
            {
                Id = dto.Id,
                CreatAt = dto.CreatAt,
                UpdateAt = dto.UpdateAt,
                Prediction = dto.Prediction,
                Score = dto.Score
            };
        }
    }
}
