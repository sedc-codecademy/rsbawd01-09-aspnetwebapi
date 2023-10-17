using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleApp.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            CreateStudent();

            Console.ReadLine();
        }

        private static async void CreateStudent() 
        {
            Console.WriteLine("Ime studenta: ");
            string fName = Console.ReadLine();

            Console.WriteLine("Prezime studenta: ");
            string lName = Console.ReadLine();

            Console.WriteLine("Godine studenta: ");
            string age = Console.ReadLine();

            Student student = new Student()
            {
                Age = int.Parse(age),
                FName = fName,
                LName = lName,
                HomeTown = "Banja Luka",
                StudentId = 10
            };

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string content = JsonConvert.SerializeObject(student);

            HttpContent httpContent = JsonContent.Create(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Content = httpContent,
                Method = HttpMethod.Post
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await
                httpClient.PostAsync(requestUri: "https://localhost:7068/api/values/create", httpRequestMessage.Content);

            if (response.IsSuccessStatusCode)
            {

            }
            
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}