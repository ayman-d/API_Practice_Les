using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.DataAccess;
using Commander.DTOs.ApplicationUserDTOs;
using Commander.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly CommanderContext _context;

        public AuthController(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              CommanderContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // [HttpGet]
        // public async Task<ApplicationUser> GetUsers()
        // {
        //     var user = await _userManager.FindByEmailAsync("bob@gmail.com");
        //     return user;
        // }

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUser>> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, false);

                if (result.Succeeded)
                {
                    return Ok(user);
                }

                return Unauthorized();
            }

            return NotFound();
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> Register(UserRegisterDTO userRegisterDTO)
        {
            var user = await _userManager.FindByEmailAsync(userRegisterDTO.Email);

            if (user != null)
            {
                return BadRequest("Email already in use");
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                DisplayName = userRegisterDTO.UserName,
                UserName = userRegisterDTO.UserName,
                Email = userRegisterDTO.Email,
                LockoutEnabled = false
            };

            var result = await _userManager.CreateAsync(newUser, userRegisterDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest("Error creating new user");
            }

            return Ok(newUser);
        }
    }
}