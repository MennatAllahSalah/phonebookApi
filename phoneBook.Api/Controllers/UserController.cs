using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<applicationUser> userManager;
        private readonly IConfiguration configuration;

        public UserController(UserManager<applicationUser> userManager, IConfiguration Configuration)
        {
            this.userManager = userManager;
            configuration = Configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
          
            applicationUser userModel = new applicationUser();
            userModel.UserName = registerDto.UserName;
            userModel.Email = registerDto.Email;
            IdentityResult result = await userManager.CreateAsync(userModel, registerDto.Password);
            if (result.Succeeded)
            {
                return Ok("Add Sucess");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return BadRequest(ModelState);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(loginDto loginDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            //check identityt  "Create Token" ==Cookie
            applicationUser userModel = await userManager.FindByNameAsync(loginDto.UserNAme);
            if (userModel != null)
            {
                if (await userManager.CheckPasswordAsync(userModel, loginDto.PAssword) == true)
                {
                    //toke base on Claims "Name &Roles &id " +Jti ==>unique Key Token "String"
                    var mytoken = await GenerateToke(userModel);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                        expiration = mytoken.ValidTo
                    });
                }
                else
                {
                    //return BadRequest("User NAme and PAssword Not Valid");
                    return Unauthorized();//401
                }
            }
            return Unauthorized();
        }
        [NonAction]
        public async Task<JwtSecurityToken> GenerateToke(applicationUser userModel)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, userModel.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));
            var roles = await userManager.GetRolesAsync(userModel);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //Jti "Identifier Token
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //---------------------------------(: Token :)--------------------------------------
            var key =
              new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecrtKey"]));
            var mytoken = new JwtSecurityToken(
                audience: configuration["JWT:ValidAudience"],
                issuer: configuration["JWT:ValidIssuer"],
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials:
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return mytoken;
        }
    }
}
