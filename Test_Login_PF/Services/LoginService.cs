using Test_Login_PF.MVVM.Models;
using RestSharp;

namespace Test_Login_PF.Services;

public class LoginService: ILoginService
{
    public async Task<UserModel> Login(string email, string password)
    {
        var client = new RestClient("http://localhost:5030/api/User/");
        var request = new RestRequest(email + "/" + password, Method.Get);
        var response = await client.ExecuteAsync<UserModel>(request);
        if (response.IsSuccessful)
        {
            return response.Data;
        }
        return null;
    }
    
    public async Task<UserModel> Register(string fullName, string email, string password)
    {
        var client = new RestClient("http://localhost:5030/api/User/");
        var request = new RestRequest("",Method.Post);
        request.AddJsonBody(new UserModel {FullName = fullName, Email = email, Password = password });
        var response = await client.ExecuteAsync<UserModel>(request);
        if (response.IsSuccessful)
        {
            return response.Data;
        }
        return null;
    }
}