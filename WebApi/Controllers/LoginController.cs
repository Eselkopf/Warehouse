using Authorization.Handlers;
using Authorization.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginHandler loginHandler;

        public LoginController(LoginHandler loginHandler)
        {
            this.loginHandler = loginHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginModel user)
        {
            var token = await loginHandler.Login(user);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
