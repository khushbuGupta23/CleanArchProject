using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using signzy.API.Attribute;
using signzy.Application.Interfaces;
using signzy.Domain.Models;

namespace signzy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginservice _loginService;

        public LoginController(ILoginservice loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<LoginAuth> LoginVerificationAsync(string username, string password)
        {
            return await _loginService.AuthenticateAsync(username, password);
        }

    }
}
