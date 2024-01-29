using System;
using suikut.Services;
using ReactiveUI;
using Splat;
using suikut.Models;
using suikut.ViewModels.Niveaux;

namespace suikut.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;
    
    private readonly ISuichukoService SuichukoService; 

    public MainWindowViewModel()
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
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

    public void PlayLevel(object niveauObj)
    {
        Niveau niveau = (Niveau)niveauObj;
        
        // Définir le string qui contient le nom du view model
        string nomViewModel = "suikut.ViewModels.Niveaux." + niveau.Libelle + "LevelViewModel,suikut.ViewModels.Niveaux";

        // Obtenir le type du view model à partir du nom
        Type typeViewModel = Type.GetType(nomViewModel);

        // Résoudre le view model à partir du conteneur Splat
        object viewModelObj = Locator.Current.GetService(typeViewModel);

        dynamic viewModel = Convert.ChangeType(viewModelObj, typeViewModel);
        
        ContentViewModel = viewModel;
    }
}