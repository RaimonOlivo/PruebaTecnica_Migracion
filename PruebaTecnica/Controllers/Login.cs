using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private static string fakeUserID = "fulanox";
        private static string fakeUserPassword = "letmein";

        [HttpPost]
        public ActionResult<LoginResult> attempLogin(LoginCredentials credentials)
        {
            if(credentials.username == fakeUserID && credentials.password == fakeUserPassword)
            {
                return new LoginResult { loginResult = "success" };
            }
            return NotFound();
        }
    }

    // Util classes
    public class LoginCredentials
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginResult
    {
        public string loginResult { get; set; }
    }
}
