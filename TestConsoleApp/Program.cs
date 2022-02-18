using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestConsoleApp
{
    internal class Program
    {


        public async void DataPost(Account data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44342/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                
                HttpResponseMessage response = await client.PostAsJsonAsync("Account", data);


                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsAsync<Account>();
                    Console.WriteLine("Id:{0}\tName:{1}\tAccountNumber:{2}", responseData.Id, responseData.Name, responseData.AccountNumber);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

        }

        static void Main(string[] args)
        {
            var account = new Account() { Id = 1, Name = "Test Name", AccountNumber = 12132323 };

            Program pr = new Program();

            pr.DataPost(account);

            Console.WriteLine("Data Posted to web api");
        }
    }
}

