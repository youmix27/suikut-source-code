using suikut.Services;
using ReactiveUI;
using suikut.Models;

namespace suikut.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel()
    {
        Login = new LoginViewModel();
        _contentViewModel = Login;
    }

    public LoginViewModel Login { get; }
    
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void Register()
    {
        ContentViewModel = new RegisterViewModel();
    }
    public void GoLogin()
    {
        ContentViewModel = new LoginViewModel();
    }
    
    public void GoLevelMenu()
    {
        ContentViewModel = new LevelSelectorViewModel();
    }
}