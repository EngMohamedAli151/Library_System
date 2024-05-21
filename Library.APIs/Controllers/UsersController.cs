using Library.Core.DTO;
using Library.DB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            this.config = config;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = _userService.FindUserByEmailAndPassword(model.Email, model.Password);
            if (user != null)
            {
                var token = GenerateToken();
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });


            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromForm] RegistrationDto model)
        {
            var userExists = _userService.FindUserByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, "User already exists!");


            var result = _userService.Add(new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password

            });

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "User creation failed! Please check user details and try again.");

            return Ok("User created successfully!");
        }


        private JwtSecurityToken GenerateToken()
        {


            SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

            SigningCredentials signincred =
                           new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Create token
            JwtSecurityToken mytoken = new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],//url web api
                audience: config["JWT:ValidAudiance"],//url consumer angular
                claims: new List<Claim>(),
                expires: DateTime.Now.AddHours(5),
                signingCredentials: signincred
                );

            return mytoken;
        }
    }
}
