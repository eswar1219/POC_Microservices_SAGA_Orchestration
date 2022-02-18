using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        public static List<Payment> userPayments = new List<Payment>();

        [HttpGet]
        public List<Payment> GET()
        {
            return userPayments;
        }

        [HttpPost]
        public Payment Post([FromBody] int userId)
        {
            if (userId <= 0)
                throw new Exception("Payment filed due to invalid user id ");

            userPayments.Add(new Payment { Id = Guid.NewGuid(), UserId = userId });

            return userPayments.Where(x => x.UserId == userId).FirstOrDefault();
        }

        [HttpDelete("{id}")]
        public string Delete([FromBody] Guid id)
        {
            userPayments.RemoveAll(x => x.Id == id);

            return "paymentId: " + id + " details deleted successfully."; ;
        }
    }
}
