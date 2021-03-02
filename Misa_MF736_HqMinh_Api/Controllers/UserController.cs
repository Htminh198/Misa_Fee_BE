using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Misa_MF736_HqMinh_Common.Models;
using Misa_MF736_HqMinh_Service.UserService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Misa_MF736_HqMinh_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        IUserService _service;
        public UserController(IUserService userService) : base(userService)
        {
            _service = userService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var rs = await _service.Login(user.UserName, user.Password);
            //if (rs.Success == false)
            //{
            //    return StatusCode(400, rs.Data);
            //}
            if (rs.Success == true)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var tokenOptions = new JwtSecurityToken
                    (
                        issuer: "https://localhost:44307",
                        audience: "https://localhost:44307",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { rs.Data, Token = tokenString });
                //return StatusCode(200,new { rs.Data, Token = tokenString });
            }
            return Unauthorized();

        }
    }
}
