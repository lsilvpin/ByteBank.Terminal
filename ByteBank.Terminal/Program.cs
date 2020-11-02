using ByteBank.Terminal.Infraestrutura;

namespace ByteBank.Terminal
{
    class Program
    {
        private const string prefixe = "http://localhost:5341/";

        static void Main(string[] args)
        {
            var prefixes = new string[] { prefixe };
            var webApp = new WebApplication(prefixes);
            webApp.Start();
        }
    }
}
