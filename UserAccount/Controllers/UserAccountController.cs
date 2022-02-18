using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UserAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : Controller
    {

        public static List<UserAccount> userAccounts = new List<UserAccount>();

        [HttpGet]
        public List<UserAccount> Get()
        {
            return userAccounts;
        }

        [HttpPost]
        public UserAccount Post([FromBody] UserAccount user)
        {

            userAccounts.Add(user);

            return user;

        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            userAccounts.RemoveAll(x => x.Id == id);

            return "userId: " + id + " details deleted successfully."; ;
        }

    }
}
