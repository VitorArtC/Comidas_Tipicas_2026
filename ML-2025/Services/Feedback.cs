using ML_2025.Models;
using System.CodeDom.Compiler;

namespace ML_2025.Services
{
    public class Feedback
    {
        public void GenerateFeedback(string input, string resposta, EnumTipoFeedback.feedback tipoFeedback)
        {
            string log = DateTime.Now.ToString("dd/MM/yyyy HH:mm" + " - " + input + " | Resposta: " + resposta + " | Feedback: " + tipoFeedback);

            string caminho = @"Logs\Feedback.txt";
            File.AppendAllText(caminho, log +"\n");
        }
    }
}
