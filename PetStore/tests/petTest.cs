using System.IO.IsolatedStorage;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json; // Newtonsoft.Json importado para usar JsonConvert.
using System.IO; // Certifique-se de ter System.IO importado para usar File.
using Models;
using Formatting = Newtonsoft.Json.Formatting;




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

            // Converte o nome do responseBody para uma string
            string name = responseBody.name.ToString();

            // Verifica se o nome é igual a "Trick"
            Assert.That(name, Is.EqualTo("Trick"));

            // Obtém o status do responseBody
            string status = responseBody.status;

            // Verifica se o status é igual a "available"
            Assert.That(status, Is.EqualTo("available"));

        }


        [Test, Order(2)]
        public void GetPetTest()
        {
            int petId = 4303300;
            String petName = "Trick";
            // Cria uma instância do cliente RestSharp.
            var client = new RestClient(BASE_URL);

            // Cria uma solicitação HTTP GET para o recurso "pet" com o ID desejado.
            var request = new RestRequest($"pet/{petId}", Method.Get);

            // Envia a solicitação para o servidor e recebe a resposta.
            var response = client.Execute(request);

            // Verifica se a solicitação foi bem-sucedida com base no código de status HTTP.
            Assert.IsTrue(response.IsSuccessful);

            // Desserializa o conteúdo da resposta JSON em um objeto C# dinâmico.
            var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

            Console.WriteLine(responseBody);

            // Verifica se o código de status da resposta é igual a 200.
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That((int)responseBody.id, Is.EqualTo(petId));
            Assert.That(responseBody.name.ToString(), Is.EqualTo(petName));


            // Agora você pode realizar mais verificações com base nas informações do animal de estimação retornado.
            // Por exemplo, você pode verificar o ID, o nome, o status, etc.
        }



        [Test, Order(3)]
        public void PutPetTest()
        {
            // Cria uma instância de PetModel
            PetModel petModel = new PetModel();
            petModel.id = 4303300;
            petModel.category = new Category(1, "PatrickLeo");
            petModel.name = "LeandrinhoPTK";
            petModel.photoUrls = new String[] { "" };
            petModel.tags = new Tag[]{new Tag(1, "vacinadão"),
                              new Tag(2, "castradão")};
            petModel.status = "available";

            // Serializa o objeto PetModel em uma representação JSON
            String jsonBody = JsonConvert.SerializeObject(petModel, Formatting.Indented); 
            Console.WriteLine(jsonBody);

            // Cria um cliente REST
            var client = new RestClient(BASE_URL);

            // Cria uma solicitação HTTP do tipo PUT para a rota "pet"
            var request = new RestRequest("pet", Method.Put);
            // Adiciona o corpo da solicitação, que contém o JSON serializado
            request.AddBody(jsonBody);

            // Envia a solicitação ao servidor
            var response = client.Execute(request);

            // Desserializa a resposta JSON em um objeto dinâmico
            var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(responseBody);

            // Verifica se o código de status da resposta é igual a 200 (sucesso)
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }

        [Test, Order(4)]
        public void GetPetTest2()
        {
            int petId = 4303300;
            String petName = "LeandrinhoPTK";
            // Cria uma instância do cliente RestSharp.
            var client = new RestClient(BASE_URL);

            // Cria uma solicitação HTTP GET para o recurso "pet" com o ID desejado.
            var request = new RestRequest($"pet/{petId}", Method.Get);

            // Envia a solicitação para o servidor e recebe a resposta.
            var response = client.Execute(request);

            // Verifica se a solicitação foi bem-sucedida com base no código de status HTTP.
            Assert.IsTrue(response.IsSuccessful);

            // Desserializa o conteúdo da resposta JSON em um objeto C# dinâmico.
            var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);

            Console.WriteLine(responseBody);

            // Verifica se o código de status da resposta é igual a 200.
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That((int)responseBody.id, Is.EqualTo(petId));
            Assert.That(responseBody.name.ToString(), Is.EqualTo(petName)); 


            // Agora você pode realizar mais verificações com base nas informações do animal de estimação retornado.
            // Por exemplo, você pode verificar o ID, o nome, o status, etc.
        }

    }
}