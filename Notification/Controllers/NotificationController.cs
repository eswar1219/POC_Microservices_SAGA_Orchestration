using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Models;
using DataBase;

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {


        public static List<Models.Notification> _notifications = new List<Models.Notification>();


        public readonly INotificationService _data;

        public NotificationController(INotificationService notificationService)
        {
            _data = notificationService;
        }

        [HttpGet]
        public List<Models.Notification> Get()
        {
            return _notifications;
        }

        [HttpPost]
        public string Post([FromBody] Models.Notification data)
        {
            var response = _data.Insert(data);

            return response.Message;

        }

    }
}
