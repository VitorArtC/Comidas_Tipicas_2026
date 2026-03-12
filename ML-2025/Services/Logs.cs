namespace ML_2025.Services
{
    public class Logs
    {

        public void GenerateLogRequest(string input)
        {
            var log = DateTime.Now.ToString("dd/MM/yyyy HH:mm"+" - "+"input");
        }

        public void GenerateLogRequestResponse(string input, string resposta)
        {
            var log = DateTime.Now.ToString("dd/MM/yyyy HH:mm" + " - " + "input"+ resposta);
        }
    }
}
