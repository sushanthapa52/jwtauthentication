using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test_webapi_notification.Models;
using test_webapi_notification.Repository;

namespace test_webapi_notification.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IJWTManagerRepository _jWTManager;


        public UsersController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;

        }
        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
            {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
            };

            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
