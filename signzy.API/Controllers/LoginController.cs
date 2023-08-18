using Microsoft.AspNetCore.Mvc;
using signzy.Application.Interfaces;
using signzy.Domain.Models;

namespace signzy.API.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IUserService _loginService;

        public LoginController(IUserService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<LoginAuth> LoginVerificationAsync(string username, string password)
        {
            return await _loginService.AuthenticateAsync(username, password);
        }

    }
}
