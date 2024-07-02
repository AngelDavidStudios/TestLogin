using Test_Login_PF.MVVM.Models;

namespace Test_Login_PF.Services;

public interface ILoginService
{
    Task<UserModel> Login(string email, string password);
}