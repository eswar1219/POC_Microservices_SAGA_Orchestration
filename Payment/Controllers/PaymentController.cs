using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using DataBase;

namespace Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        public readonly IPaymentService _data;

        public PaymentController(IPaymentService paymentService)
        {
            _data = paymentService;
        }


        [HttpGet]
        public List<Models.Payment> GET()
        {
            return _data.GetAll().ToList();
        }

        [HttpPost]
        public Models.Payment Post([FromBody] UserAccount data)
        {
            if (data.AccountNumber.Length < 4)
                throw new Exception("Payment filed due to invalid account number");

            var payrespo = _data.Insert(new Models.Payment { Id = Guid.NewGuid(), UserId = data.Id });

            return payrespo;
        }

        [HttpDelete("{id}")]
        public string Delete([FromBody] int id)
        {
            _data.Delete(id);

            return "paymentId: " + id + " details deleted successfully.";
        }
    }
}
