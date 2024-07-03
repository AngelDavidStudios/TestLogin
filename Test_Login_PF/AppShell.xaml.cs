using Test_Login_PF.MVVM.ViewModels;

namespace Test_Login_PF;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = new AppShellViewModel();
    }
}