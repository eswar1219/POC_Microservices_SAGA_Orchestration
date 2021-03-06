using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Orchestrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactroy;

        private readonly ILogger<AccountController> _logger;

        Models.Notification Notification = new Models.Notification();

        public static List<string> logs = new List<string>();
        public AccountController(IHttpClientFactory httpClientFactory, ILogger<AccountController> logger)
        {
            this.httpClientFactroy = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return logs;
        }

        [HttpPost]
        public async Task<Models.AccountResponse> Post([FromBody] Models.UserAccount data)
        {
            var ErrorMessage = string.Empty;
            var paymentData = string.Empty;
            var notificationResponse = string.Empty;


            var request = JsonConvert.SerializeObject(data);

            // Create User
            _logger.LogInformation("user creation process started..", data);
            var userClient = httpClientFactroy.CreateClient("UserAccount");
            var userResponse = await userClient.PostAsync("api/UserAccount",
                new StringContent(request, Encoding.UTF8, "application/JSON"));

            var UserData = userResponse.Content.ReadAsStringAsync().Result;
            _logger.LogInformation("User creation process completed", UserData);
            data.Id = JsonConvert.DeserializeObject<Models.UserAccount>(UserData).Id;
            Notification.UserId = data.Id;


            // Payment 
            try
            {
                request = JsonConvert.SerializeObject(data);
                _logger.LogInformation("user payment process started..", DateTime.Now);

                var paymentClient = httpClientFactroy.CreateClient("Payment");
                var paymentResponse = await paymentClient.PostAsync("api/Payment",
                    new StringContent(request, Encoding.UTF8, "application/JSON"));

                paymentData = paymentResponse.Content.ReadAsStringAsync().Result;

                if (paymentResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    _logger.LogInformation("User payment process failed. :( , Rollback process intiated ...", DateTime.Now);

                    throw new Exception(paymentResponse.ReasonPhrase);
                }
                else
                {
                    _logger.LogInformation("User payment process completed..", DateTime.Now);

                }

            }
            catch (Exception ex)
            {
                Thread.Sleep(3000);

                await userClient.DeleteAsync($"/api/UserAccount/{data.Id}");

                _logger.LogInformation("User details details deleted.", DateTime.Now);

                notificationResponse = await SendNotification(data, "User account details deleted. due to payment faild.");

                return new Models.AccountResponse
                {
                    Response = "No Response",
                    Message = "User account process faild due to Payment process faild." + " Exception Message :" + ex.Message.ToString()
                };

            }


            // Notification

            _logger.LogInformation("Notification process started..", DateTime.Now);
            notificationResponse = await SendNotification(data, "User Created Successfully");

            _logger.LogInformation("sent Notification details to user...", DateTime.Now);

            var report = $"User: {UserData},Payment:{ paymentData }, Notification:{notificationResponse} ";

            return new Models.AccountResponse
            {
                Response = report,
                Message = "User account creation process successfully completed."
            };
        }

        private async Task<string> SendNotification(Models.UserAccount data, string message)
        {

            Notification.Message = message;
            Notification.UserId = data.Id;
            var request = JsonConvert.SerializeObject(Notification);
            _logger.LogInformation("Notification process started..", DateTime.Now);

            var notificationClient = httpClientFactroy.CreateClient("Notification");
            var notificationResponse = await notificationClient.PostAsync("api/Notification",
                new StringContent(request, Encoding.UTF8, "application/JSON"));

            var notificationData = notificationResponse.Content.ReadAsStringAsync().Result;
            _logger.LogInformation("sent Notification details to user...", DateTime.Now);

            return notificationData;
        }

    }
}
