using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProjectServer.Dtos;
using System.IdentityModel.Tokens.Jwt;

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<WorldCitiesUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(Dtos.LoginRequest request)
        {
            WorldCitiesUser user = await userManager.FindByNameAsync(request.UserName);
            if (user == null) {
                return Unauthorized("Unknown user");
            }

            bool success = await userManager.CheckPasswordAsync(user, request.Password);

            if (!success) {
                return Unauthorized("Bad password");
            }

            JwtSecurityToken token = await jwtHandler.GetTokenAsync(user);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Ok",
                Token = tokenString
            });
        }
    }
}
