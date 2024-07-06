using Test_Login_PF.MVVM.ViewModels;

namespace Test_Login_PF.MVVM.Views;

public partial class SignUpView : ContentPage
{
    public SignUpView()
    {
        InitializeComponent();
        BindingContext = new SignUpViewModel();
    }
}