using ML_2025.DTOs;
using ML_2025.Entidades;

namespace ML_2025.Mappers
{
    public static class TreinamentoMapper
    {
        public static TreinamentoDTO ToDTO(this TreinamentoData entity)
        {
            if (entity == null) return null;
            return new TreinamentoDTO
            {
                Id = entity.Id,
                CreatAt = entity.CreatAt,
                UpdateAt = entity.UpdateAt,
                Text = entity.Text,
                Label = entity.Label
            };
        }

        public static TreinamentoData ToEntity(this TreinamentoDTO dto)
        {
            if (dto == null) return null;
            return new TreinamentoData
            {
                Id = dto.Id,
                CreatAt = dto.CreatAt,
                UpdateAt = dto.UpdateAt,
                Text = dto.Text,
                Label = dto.Label
            };
        }
    }
}
