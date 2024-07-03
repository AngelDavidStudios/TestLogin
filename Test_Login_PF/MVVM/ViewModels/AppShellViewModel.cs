using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Test_Login_PF.MVVM.ViewModels;

public partial class AppShellViewModel: ObservableObject
{
    [RelayCommand]
    async void SignOut()
    {
        if (Preferences.ContainsKey(nameof(App.User)))
        {
            Preferences.Remove(nameof(App.User));
        }
        await Shell.Current.GoToAsync("..");
    }
}