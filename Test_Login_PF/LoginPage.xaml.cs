using Test_Login_PF.MVVM.ViewModels;

namespace Test_Login_PF;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageViewModel();
    }
}