namespace ML_2025.Services
{
    public class Logs
    {

        public void GenerateLogRequest(string input)
        {
            string log = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + " - " + input;

            string Caminho = @"Logs\LogRequisicao.txt";
            File.AppendAllText(Caminho, log + "\n");

        }

        public void GenerateLogRequestResponse(string input, string resposta)
        {
            string log = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss.fff") + " - " + input + " - " + resposta;

            string Caminho = @"Logs\LogRequisicaoResposta.txt";
            File.AppendAllText(Caminho, log + "\n");

        }
    }
}
