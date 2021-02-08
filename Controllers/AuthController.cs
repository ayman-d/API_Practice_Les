using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data.ApplicationUserRepo;
using Commander.DataAccess;
using Commander.DTOs.ApplicationUserDTOs;
using Commander.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IApplicationUserRepository _applicationUserRepository;


        // do I even need UserManager and SignInManager here?? research
        public AuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IApplicationUserRepository applicationUserRepository)
        {
            _signInManager = signInManager;
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResult>> Login(UserLoginDTO userLoginDTO)
        {
            // store the result from the repository
            var result = await _applicationUserRepository.Login(userLoginDTO);

            // if not successful, send the object in an UnAuthorized 401 response
            if (!result.Successful)
            {
                return Unauthorized(result);
            }

            // if successful send the object containing the token
            return result;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResult>> Register(UserRegisterDTO userRegisterDto)
        {
            var result = await _applicationUserRepository.Register(userRegisterDto);

            if (!result.Successful)
            {
                return BadRequest(result);
            }

            return result;
        }

    }

}