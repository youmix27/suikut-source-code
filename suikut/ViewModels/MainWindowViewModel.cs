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
        Register = new RegisterViewModel();
        LevelSelector = new LevelSelectorViewModel();
        _contentViewModel = Login;
    }

    public LoginViewModel Login { get; }
    public RegisterViewModel Register { get; }
    public LevelSelectorViewModel LevelSelector { get; }
    public LevelViewModel LevelMenu { get; set; }
    
    
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void GoRegister()
    {
        // On vide les variables d'environnement à la déconnexion
        Environment.SetEnvironmentVariable("USER_PSEUDO", "");
        Environment.SetEnvironmentVariable("USER_ID", "");
        ContentViewModel = Register;
    }
    public void GoLogin()
    {
        ContentViewModel = Login;
    }
    
    public void GoLevelSelecorMenu()
    {
        ContentViewModel = LevelSelector;
    }
    
    public void GoLevelMenu(object niveau)
    {
        LevelMenu = new LevelViewModel((Niveau)niveau);
        ContentViewModel = LevelMenu;
    }
}