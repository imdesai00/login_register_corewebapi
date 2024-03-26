using login_register_corewebapi.DataAccess;
using login_register_corewebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace login_register_corewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataAccess _userDataAccess;
        private readonly IJwttoken _jwttoken;

        public UserController(IUserDataAccess userDataAccess, IJwttoken jwttoken)
        {
            _userDataAccess = userDataAccess;
            _jwttoken = jwttoken;
        }

        [HttpPost("login")]
        public IActionResult GetUserbyusernameandpassword(UserLoginModel model)
        {
            if (_userDataAccess.ValidateCredentials(model.Username, model.Password))
            {
                var token = _jwttoken.GenerateToken(model.Username);
                var refoken = _jwttoken.GenerateReferenceToken(token);
                //var gettoken = _jwtService.GetJwtToken(refoken);
                return Ok(new { Token = token, RefToken = refoken });
            }
            return Unauthorized();
        }
    }
}
