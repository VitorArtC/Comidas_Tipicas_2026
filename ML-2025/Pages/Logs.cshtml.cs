using Microsoft.AspNetCore.Mvc.RazorPages;
using ML_2025.DTOs;
using System.Collections.Generic;
using System.IO;

namespace ML_2025.Pages
{
    public class LogsModel : PageModel
    {
        public List<LogEntry> LogEntries { get; set; } = new List<LogEntry>();

        public void OnGet()
        {
            string logFilePath = @"Logs\LogRequisicaoResposta.txt";
            if (System.IO.File.Exists(logFilePath))
            {
                var lines = System.IO.File.ReadAllLines(logFilePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(" - ");
                    if (parts.Length >= 3)
                    {
                        LogEntries.Add(new LogEntry
                        {
                            Timestamp = parts[0].Trim(),
                            Input = parts[1].Trim(),
                            Result = parts[2].Trim()
                        });
                    }
                    else
                    {
                        LogEntries.Add(new LogEntry
                        {
                            Timestamp = "-",
                            Input = line,
                            Result = "-"
                        });
                    }
                }

                // Inverte para mostrar os logs mais recentes primeiro
                LogEntries.Reverse();
            }
        }
    }
}
