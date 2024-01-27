using System;
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
        // On vide les variables d'environnement à la déconnexion
        Environment.SetEnvironmentVariable("USER_PSEUDO", "");
        Environment.SetEnvironmentVariable("USER_ID", "");
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