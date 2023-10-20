using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json; // Newtonsoft.Json importado para usar JsonConvert.
using System.IO; // Certifique-se de ter System.IO importado para usar File.

namespace Pet
{
    public class petTest
    {
        private const string BASE_URL = "https://petstore.swagger.io/v2/";

        [Test, Order(1)]
        public void PostPetTest()
        {
            // Cria uma instância do cliente RestSharp.
            var client = new RestClient(BASE_URL);

            // Cria uma solicitação HTTP POST para o recurso "pet".
            var request = new RestRequest("pet", Method.Post);

            // Lê o conteúdo do arquivo JSON de um caminho específico.
            String jsonBody = File.ReadAllText(@"C:\Users\Usuario\Documents\QA-Trilha\Iterasys\PetStore\fixtures\pet1.json");

            // Adiciona o corpo da solicitação com o JSON lido.
            request.AddJsonBody(jsonBody);

            // Envia a solicitação para o servidor e recebe a resposta.
            var response = client.Execute(request);

            // Verifica se a solicitação foi bem-sucedida com base no código de status HTTP.
            Assert.IsTrue(response.IsSuccessful);

            // Desserializa o conteúdo da resposta JSON em um objeto C# dinâmico.
            var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

            Console.WriteLine(responseBody);

            // Verifica se o código de status da resposta é igual a 200.
            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            string name = responseBody.name.ToString();
            Assert.That(name, Is.EqualTo("Trick"));

            string status = responseBody.status;
            Assert.That(status, Is.EqualTo("available"));
        }
    }
}
