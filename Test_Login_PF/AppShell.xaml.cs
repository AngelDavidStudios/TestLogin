using Test_Login_PF.MVVM.ViewModels;
using Test_Login_PF.MVVM.Views;

namespace Test_Login_PF;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = new AppShellViewModel();
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
    }
}