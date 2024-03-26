using login_register_corewebapi.DataAccess;
using login_register_corewebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace login_register_corewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterDataAccess _registerDataAccess;

        public RegisterController(IRegisterDataAccess registerDataAccess)
        {
            _registerDataAccess = registerDataAccess;
        }


        [HttpPost]
        public IActionResult createuser(User user)
        {
            _registerDataAccess.createuser(user);
            return Ok();
        }
    }
}
