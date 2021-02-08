using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Commander.DTOs.ApplicationUserDTOs;
using Commander.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Data.ApplicationUserRepo
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<UserResult> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (user == null)
            {
                return new UserResult
                {
                    Username = null,
                    Email = null,
                    Successful = false,
                    Message = "User does not exist",
                    Token = null
                };
            }

            var results = await _signInManager.CheckPasswordSignInAsync(
                user, userLoginDTO.Password, false
                );

            if (results.Succeeded)
            {
                return new UserResult
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Successful = true,
                    Message = "Login successful",
                    Token = "Token will go here"
                };
            }

            return new UserResult
            {
                Username = null,
                Email = null,
                Successful = false,
                Message = "Login failed",
                Token = null
            };
        }

        public ApplicationUser Register(UserRegisterDTO userRegisterDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}