using Finance.Database.Factory;
using Finance.Models;

namespace Finance.Interface
{
    public interface IAccountService
    {
        Task<bool> CheckUserExist(string emailAddress);
        Task<bool> TryCreateUserInfo(RegisterForm registerForm);
        Task<bool> CheckPasscode(string email, string password);
        Task<AppUser?> GetUserByMail(string emailAddress);
        Task<bool> TryLoginUser(LoginForm loginForm);
        Task<bool> UpdatePassword(ChangePassword changePassword);
        Task<bool> LogoutUser();
    }
}
