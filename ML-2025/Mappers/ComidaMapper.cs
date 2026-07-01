using ML_2025.DTOs;
using ML_2025.Entidades;

namespace ML_2025.Mappers
{
    public static class ComidaMapper
    {
        public static ComidaDTO ToDTO(this ComidaData entity)
        {
            if (entity == null) return null;
            return new ComidaDTO
            {
                Id = entity.Id,
                CreatAt = entity.CreatAt,
                UpdateAt = entity.UpdateAt,
                Prato = entity.Prato,
                Regiao = entity.Regiao,
                Label = entity.Label
            };
        }

        public static ComidaData ToEntity(this ComidaDTO dto)
        {
            if (dto == null) return null;
            return new ComidaData
            {
                Id = dto.Id,
                CreatAt = dto.CreatAt,
                UpdateAt = dto.UpdateAt,
                Prato = dto.Prato,
                Regiao = dto.Regiao,
                Label = dto.Label
            };
        }
    }
}
