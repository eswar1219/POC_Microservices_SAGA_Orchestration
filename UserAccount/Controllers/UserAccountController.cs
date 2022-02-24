using DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace UserAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : Controller
    {

        public readonly IUserAccountService _data;

        public UserAccountController(IUserAccountService userService)
        {
            _data = userService;
        }


        [HttpGet]
        public List<Models.UserAccount> Get()
        {

            var data = _data.GetAll().ToList();
            return data;
        }

        [HttpPost]
        public Models.UserAccount Post([FromBody] Models.UserAccount user)
        {

            var userRespo = _data.Insert(user);

            return userRespo;

        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _data.Delete(id);

            return "userId: " + id + " details deleted successfully."; ;
        }

    }
}
