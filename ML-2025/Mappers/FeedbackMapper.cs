using ML_2025.DTOs;
using ML_2025.Tables;

namespace ML_2025.Mappers
{
    public static class FeedbackMapper
    {
        public static FeedbackDTO ToDTO(this FeedbackData entity)
        {
            if (entity == null) return null;
            return new FeedbackDTO
            {
                Id = entity.Id,
                CreatAt = entity.CreatAt,
                UpdateAt = entity.UpdateAt,
                Input = entity.Input,
                Tipo = entity.Tipo
            };
        }

        public static FeedbackData ToEntity(this FeedbackDTO dto)
        {
            if (dto == null) return null;
            return new FeedbackData
            {
                Id = dto.Id,
                CreatAt = dto.CreatAt,
                UpdateAt = dto.UpdateAt,
                Input = dto.Input,
                Tipo = dto.Tipo
            };
        }
    }
}
