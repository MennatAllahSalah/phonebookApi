using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using phoneBook.Application.interfaces;
using Microsoft.AspNetCore.Identity;
using phoneBookDomain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using IdentityResult = Microsoft.AspNetCore.Identity.IdentityResult;

namespace phoneBook.persistance.Reprosatories
{
    public class UserReprosatory : IUserReprosatory<applicationUser>
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<applicationUser> _userManager;
        private readonly IConfiguration configuration;

        public UserReprosatory(Microsoft.AspNetCore.Identity.UserManager<applicationUser> userManager, IConfiguration Configuration)
        {
            _userManager = userManager;
            configuration = Configuration;
        }

        public async Task<applicationUser> GenerateToke(applicationUser userModel)
        {
            return await GenerateToke(userModel);
        }

        public async Task<applicationUser> Login(loginDto loginDto)
        {
            return await _userManager.FindByNameAsync(loginDto.UserNAme);
        }

        public async Task<applicationUser> Register(RegisterDto registerDto)
        {
            applicationUser userModel = new applicationUser();
            userModel.UserName = registerDto.UserName;
            userModel.Email = registerDto.Email;
         IdentityResult result= await _userManager.CreateAsync(userModel, registerDto.Password);
            return await _userManager.CreateAsync(userModel, registerDto.Password);

        }
    }
}


   
   

