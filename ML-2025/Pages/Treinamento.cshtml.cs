using Microsoft.AspNetCore.Mvc.RazorPages;
using ML_2025.DTOs;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ML_2025.Pages
{
    public class TreinamentoModel : PageModel
    {
        public List<TreinamentoEntry> DadosTreinamento { get; set; } = new List<TreinamentoEntry>();

        public void OnGet()
        {
            string caminho = @"MLModels\sentiment.csv";
            if (System.IO.File.Exists(caminho))
            {
                var lines = System.IO.File.ReadAllLines(caminho).Skip(1); // skip header
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var firstComma = line.IndexOf(',');
                    if(firstComma > 0)
                    {
                        var labelStr = line.Substring(0, firstComma).Trim();
                        var textStr = line.Substring(firstComma + 1).Trim('"', ' ');
                        
                        DadosTreinamento.Add(new TreinamentoEntry
                        {
                            Label = labelStr.Equals("true", System.StringComparison.OrdinalIgnoreCase),
                            Text = textStr
                        });
                    }
                }
            }
        }
    }
}
