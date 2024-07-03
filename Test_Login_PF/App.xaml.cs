using Test_Login_PF.MVVM.Models;

namespace Test_Login_PF;

public partial class App : Application
{
    public static UserModel User;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}