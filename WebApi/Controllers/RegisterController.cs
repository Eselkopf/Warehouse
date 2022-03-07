using Authorization.Handlers;
using Authorization.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegisterHandler registerHandler;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginModel user)
        {
            await registerHandler.Register(user);
            return Ok();
        }
    }
}
