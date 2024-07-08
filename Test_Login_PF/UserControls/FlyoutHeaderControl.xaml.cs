namespace Test_Login_PF.UserControls;

public partial class FlyoutHeaderControl : ContentView
{
    public FlyoutHeaderControl()
    {
        InitializeComponent();
        if(App.User != null)
        {
            lblUserName.Text = "Logged in as: " + App.User.FullName;
            lblUserEmail.Text = App.User.Email;
        }
    }
}