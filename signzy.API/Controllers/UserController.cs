using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using signzy.API.Attribute;
using signzy.Application.Interfaces;
using signzy.Domain.Entities;
using signzy.Domain.Models;

namespace signzy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(Authentication))]
    public class UserController : Controller
    {
        private readonly IUserService _loginService;

        public UserController(IUserService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _loginService.GetAllUser();
        }

    }
}
