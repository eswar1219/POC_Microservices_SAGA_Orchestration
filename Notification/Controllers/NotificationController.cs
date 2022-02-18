using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        public static List<Notification> _notifications = new List<Notification>();

        [HttpGet]
        public List<Notification> Get()
        {
            return _notifications;
        }

        [HttpPost]
        public string Post([FromBody] string data)
        {
            var msg = data + "User Creation Process successfully completed";

            _notifications.Add(new Notification { Id = Guid.NewGuid(), Message = msg });

            return msg;

        }

    }
}
