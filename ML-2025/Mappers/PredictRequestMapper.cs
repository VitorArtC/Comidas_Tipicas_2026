using ML_2025.DTOs;
using ML_2025.Entidades;

namespace ML_2025.Mappers
{
    public static class PredictRequestMapper
    {
        public static PredictRequestDTO ToDTO(this PredictRequestData entity)
        {
            if (entity == null) return null;
            return new PredictRequestDTO
            {
                Id = entity.Id,
                CreatAt = entity.CreatAt,
                UpdateAt = entity.UpdateAt,
                Text = entity.Text
            };
        }

        public static PredictRequestData ToEntity(this PredictRequestDTO dto)
        {
            if (dto == null) return null;
            return new PredictRequestData
            {
                Id = dto.Id,
                CreatAt = dto.CreatAt,
                UpdateAt = dto.UpdateAt,
                Text = dto.Text
            };
        }
    }
}
