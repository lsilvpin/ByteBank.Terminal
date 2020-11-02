using System;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace ByteBank.Terminal.Infraestrutura
{
    public class WebApplication
    {
        private const string contentType = "text/html; charset=utf-8";
        private const string responseContent = "Hello World";

        private readonly string[] prefixes;

        public WebApplication(string[] prefixes)
        {
            if (prefixes == null)
                throw new ArgumentNullException(nameof(prefixes));

            this.prefixes = prefixes;
        }

        public void Start()
        {
            var httpListener = new HttpListener();

            foreach (var prefixe in prefixes)
                httpListener.Prefixes.Add(prefixe);

            httpListener.Start();

            var context = httpListener.GetContext();

            var request = context.Request;
            var response = context.Response;

            response.ContentType = contentType;
            string responseMessage = responseContent;
            byte[] responseMessageBytes = Encoding.UTF8.GetBytes(responseMessage);
            response.StatusCode = 200;
            response.ContentLength64 = responseMessageBytes.Length;

            response.OutputStream.Write(responseMessageBytes, 0, responseMessageBytes.Length);
            response.OutputStream.Close();

            httpListener.Stop();
        }
    }
}
