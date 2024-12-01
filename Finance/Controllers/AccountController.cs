using Finance.Interface;
using Finance.Models;
using Finance.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(AccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(RegisterForm registerForm)
        {
            if(registerForm == null)
            {
                return BadRequest("Invalid request parameters.");
            }
            if (await _accountService.CheckUserExist(registerForm.Email)){
                return Ok($"User {registerForm.Email} Already Exists.");
            }
            if(await _accountService.TryCreateUserInfo(registerForm))
            {
                return Ok("User Registration Successful!");
            }

            return BadRequest("Error Occurred While Signin");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser(LoginForm loginForm)
        {
            if(loginForm == null)
            {
                return BadRequest("Bad Parameters");
            }
            if(await _accountService.CheckUserExist(loginForm.Email))
            {
                if(await _accountService.CheckPasscode(loginForm.Email, loginForm.Password))
                {
                    if (await _accountService.TryLoginUser(loginForm))
                    {
                        return Ok($"User Logged In {loginForm.Email}");
                    }
                    return BadRequest("Bad Parameter");
                }
                return BadRequest("User name or password incorrect");
            }
            else
            {
                return Ok("User Does not Exists Register First");
            }
        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePassword changePassword)
        {
            if(changePassword == null)
            {
                return BadRequest("Bad Parameter");
            }
            
            if(await _accountService.CheckUserExist(changePassword.Email))
            {
                if (!await _accountService.CheckPasscode(changePassword.Email, changePassword.OldPassword))
                {
                    return BadRequest($"User {changePassword.Email} Password is wrong");
                }
                if(await _accountService.UpdatePassword(changePassword))
                {
                    return Ok($"User {changePassword.Email} Password Updated Successfully!");
                }
            }
            return BadRequest("Bad Parameter");
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> LogoutUser()
        {
            if(await _accountService.LogoutUser())
            {
                return Ok($"User Logged Off Successfully!");
            }
            return BadRequest("Bad Parameter");
        }
    }
}
