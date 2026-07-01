using ML_2025.Entidades;
using ML_2025.Services.Interfaces;

namespace ML_2025.Services
{
    public class Logs
    {
        private readonly ILogDataService _logDataService;

        public Logs(ILogDataService logDataService)
        {
            _logDataService = logDataService;
        }

        public async Task GenerateLogAsync(string input, bool result, double timeResponseMs)
        {
            var entity = new LogData
            {
                Input = input,
                Result = result,
                TimeResponse = timeResponseMs,
                CreatAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            await _logDataService.CreateAsync(entity);
        }
    }
}
