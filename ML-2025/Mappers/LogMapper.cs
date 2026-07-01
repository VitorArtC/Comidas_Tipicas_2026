using ML_2025.DTOs;
using ML_2025.Entidades;

namespace ML_2025.Mappers
{
    public static class LogMapper
    {
        public static LogDTO ToDTO(this LogData entity)
        {
            if (entity == null) return null;
            return new LogDTO
            {
                Id = entity.Id,
                CreatAt = entity.CreatAt,
                UpdateAt = entity.UpdateAt,
                Input = entity.Input,
                Result = entity.Result,
                TimeResponse = entity.TimeResponse
            };
        }

        public static LogData ToEntity(this LogDTO dto)
        {
            if (dto == null) return null;
            return new LogData
            {
                Id = dto.Id,
                CreatAt = dto.CreatAt,
                UpdateAt = dto.UpdateAt,
                Input = dto.Input,
                Result = dto.Result,
                TimeResponse = dto.TimeResponse
            };
        }
    }
}
