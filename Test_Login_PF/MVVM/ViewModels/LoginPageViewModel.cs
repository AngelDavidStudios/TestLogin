using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Test_Login_PF.MVVM.Models;
using Test_Login_PF.MVVM.Views;
using Test_Login_PF.Services;
using Test_Login_PF.UserControls;

namespace Test_Login_PF.MVVM.ViewModels;

public partial class LoginPageViewModel: ObservableObject
{
    [ObservableProperty]
    private string _userName;

    [ObservableProperty]
    private string _password;

    readonly ILoginService loginService = new LoginService();

    [RelayCommand]
    public async void Login()
    {
        try {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet) {

                if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password)) {
                    UserModel user = await loginService.Login(UserName, Password);
                    if (user == null) {
                        await Shell.Current.DisplayAlert("Error", "Username/Password is incorrect", "Ok");
                        return;
                    }
                    if (Preferences.ContainsKey(nameof(App.User))) {
                        Preferences.Remove(nameof(App.User));
                    }
                    string userDetails = JsonConvert.SerializeObject(user);
                    Preferences.Set(nameof(App.User), userDetails);
                    App.User = user;
                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                    await Shell.Current.GoToAsync("//HomePage");
                } else {
                    await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                }
            } else {
                await Shell.Current.DisplayAlert("Error", "No Internet Access", "Ok");
            }
        } catch (Exception ex) {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
        }
    }
}