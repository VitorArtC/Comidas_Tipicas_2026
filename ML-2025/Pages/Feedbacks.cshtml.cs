using Microsoft.AspNetCore.Mvc.RazorPages;
using ML_2025.DTOs;
using System.Collections.Generic;
using System.IO;

namespace ML_2025.Pages
{
    public class FeedbacksModel : PageModel
    {
        public List<FeedbackEntry> Feedbacks { get; set; } = new List<FeedbackEntry>();

        public void OnGet()
        {
            string caminho = @"Logs\Feedback.txt";
            if (System.IO.File.Exists(caminho))
            {
                var lines = System.IO.File.ReadAllLines(caminho);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var entry = new FeedbackEntry();
                    var splitTrace = line.Split(" - ", 2);
                    if (splitTrace.Length == 2)
                    {
                        entry.Timestamp = splitTrace[0].Trim();
                        var rest = splitTrace[1];
                        var parts = rest.Split(" | ");
                        if (parts.Length >= 3)
                        {
                            entry.Input = parts[0].Trim();
                            var feedbackPart = parts[2].Replace("Feedback: ", "").Trim();
                            entry.Tipo = feedbackPart;
                        }
                        else
                        {
                            entry.Input = rest;
                            entry.Tipo = "-";
                        }
                    }
                    else
                    {
                        entry.Timestamp = "-";
                        entry.Input = line;
                        entry.Tipo = "-";
                    }
                    
                    Feedbacks.Add(entry);
                }
                Feedbacks.Reverse();
            }
        }
    }
}
