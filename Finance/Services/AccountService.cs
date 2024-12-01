using Finance.Database.Factory;
using Finance.Interface;
using Finance.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Finance.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly IHttpContextAccessor _contextAccessor;

        public AccountService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CheckUserExist(string emailAddress)
        {
            return await GetUserByMail(emailAddress) != null;
        }

        public async Task<bool> TryCreateUserInfo(RegisterForm registerForm)
        {
            var user = new AppUser()
            {
                UserName = TrimEmail(registerForm.Email),
                Email = registerForm.Email,
            };
            var taskCompletion = await _userManager.CreateAsync(user, registerForm.Password);
            return taskCompletion.Succeeded;
        }

        public async Task<bool> TryLoginUser(LoginForm loginForm)
        {
            var user = await GetUserByMail(loginForm.Email);
            if (user != null)
            {
               return await _signInManager.SignInAsync(user, isPersistent: false).ContinueWith(task => task.IsCompletedSuccessfully);
            }
            return false;
        }

        public async Task<bool> CheckPasscode(string email, string password)
        {
            var user = await GetUserByMail(email) ?? new AppUser();
            var taskPasscode = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return taskPasscode.Succeeded;
        }

        public async Task<bool> UpdatePassword(ChangePassword changePassword)
        {
            var user = await GetUserByMail(changePassword.Email) ?? new AppUser();
            var task = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
            if (task.Succeeded)
            {
                return await _signInManager.RefreshSignInAsync(user).ContinueWith(task => task.IsCompletedSuccessfully);
            }
            return false;
        }

        public async Task<bool> LogoutUser()
        {
            return CheckUserLoggedIn() && await _signInManager.SignOutAsync().ContinueWith(task => task.IsCompletedSuccessfully);
        }

        public async Task<AppUser?> GetUserByMail(string emailAddress)
        {
            return await _userManager.FindByEmailAsync(emailAddress);
        }

        private bool CheckUserLoggedIn()
        {
            var user = _contextAccessor?.HttpContext?.User?.Identity;
            return user != null && user.IsAuthenticated;
        }

        private static string TrimEmail(string email)
        {
            return email[..email.IndexOf('@')];
        }
    }
}
