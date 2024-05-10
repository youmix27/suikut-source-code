using System;
using suikut.Services;
using ReactiveUI;
using Splat;
using suikut.Models;
using Castle.Core.Internal;

namespace suikut.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;
    
    private readonly ISuichukoService SuichukoService; 

    public MainWindowViewModel()
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
        
        LoginViewModel = new LoginViewModel();
        _contentViewModel = LoginViewModel;
    }

    public LoginViewModel LoginViewModel { get; set; }
    public RegisterViewModel RegisterViewModel { get; set; }
    public LevelSelectorViewModel LevelSelectorViewModel { get; set; }
    public LevelViewModel LevelMenuViewModel { get; set; }
    public MainMenuViewModel MainMenuViewModel { get; set; }
    public UserViewModel UserViewModel { get; set; }
    
    
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }
    
    /*
     *
     * Méthodes nécessitant un changement de vue
     * 
     */

    public void Login()
    {
        if (LoginViewModel.Pseudo.IsNullOrEmpty()|| LoginViewModel.MotDePasse.IsNullOrEmpty()) // on vérifie que les inputs soit remplit
        {
            LoginViewModel.ErrorMessage = "Veuillez remplir les champs";
            return;
        }
        Utilisateur utilisateur = SuichukoService.FindUtilisateurByPseudo(LoginViewModel.Pseudo);
        if (utilisateur == null || !BCrypt.Net.BCrypt.Verify(LoginViewModel.MotDePasse, utilisateur.HashMdp))
        {
            LoginViewModel.ErrorMessage = "Nom d'utilisateur ou mot de passe erronés";
            return;
        }

        if (utilisateur.IsBanned)
        {
            LoginViewModel.ErrorMessage = "Utilisateur banni";
            return;
        }
        // On sauvegarde les inforamtions utilies sur l'utilisateur connecté dans nos variables d'environnement
        Environment.SetEnvironmentVariable("USER_PSEUDO", utilisateur.Pseudo);
        Environment.SetEnvironmentVariable("USER_ROLE", utilisateur.IsAdmin ? "Administrator" : "User");
        Environment.SetEnvironmentVariable("USER_ID", utilisateur.Id.ToString());
        MainMenuViewModel = new MainMenuViewModel();
        GoMainMenu();
    }

    public void Register()
    {
        if (RegisterViewModel.Pseudo.IsNullOrEmpty() || RegisterViewModel.Email.IsNullOrEmpty() || RegisterViewModel.MotDePasse.IsNullOrEmpty() || RegisterViewModel.MotDePasseConfirme.IsNullOrEmpty()) // on vérifie que les trois inputs soit remplit
        {
            return;
        }
        Utilisateur utilisateurVerification = SuichukoService.FindUtilisateurByPseudo(RegisterViewModel.Pseudo); // vérification de l'unicité du pseudo
        if (utilisateurVerification != null)
        {
            RegisterViewModel.errorMessage = "nom d'utilisateur deja utilisé";
            return;
        }
        if (RegisterViewModel.MotDePasse != RegisterViewModel.MotDePasseConfirme)
        {
            RegisterViewModel.errorMessage = "les mots de passe ne sont pas similaires";
            return;
        }
        RegisterViewModel.errorMessage = "";
        if ((!RegisterViewModel.Email.Contains('@') || RegisterViewModel.Email.StartsWith('@') ||  RegisterViewModel.Email.EndsWith('@')) || RegisterViewModel.MotDePasse.Length < 8) //on vérifie que la validité des champs
        {
            return;
        }
        Utilisateur utilisateur = new Utilisateur();
        utilisateur.Email = RegisterViewModel.Email;
        utilisateur.Pseudo = RegisterViewModel.Pseudo;
        utilisateur.HashMdp = BCrypt.Net.BCrypt.HashPassword(RegisterViewModel.MotDePasse);
        SuichukoService.InsertUtilisateur(utilisateur);
        GoLogin();
    }
    public void GoRegister()
    {
        // On vide les variables d'environnement à la déconnexion
        Environment.SetEnvironmentVariable("USER_PSEUDO", "");
        Environment.SetEnvironmentVariable("USER_ID", "");
        RegisterViewModel = new RegisterViewModel();
        ContentViewModel = RegisterViewModel;
    }
    public void GoLogin()
    {
        // On vide les variables d'environnement à la déconnexion
        Environment.SetEnvironmentVariable("USER_PSEUDO", "");
        Environment.SetEnvironmentVariable("USER_ID", "");
        LoginViewModel = new LoginViewModel();
        ContentViewModel = LoginViewModel;
    }
    
    public void GoLevelSelecorMenu()
    {
        LevelSelectorViewModel = new LevelSelectorViewModel();
        ContentViewModel = LevelSelectorViewModel;
    }
    
    public void GoMainMenu()
    {
        ContentViewModel = MainMenuViewModel;
    }
    
    public void GoLevelMenu(object niveau)
    {
        LevelMenuViewModel = new LevelViewModel((Niveau)niveau);
        ContentViewModel = LevelMenuViewModel;
    }
    
    public void GoUserMenu()
    {
        UserViewModel = new UserViewModel();
        ContentViewModel = UserViewModel;
    }

    public void PlayLevel(Niveau niveau)
    {
        
        // Définir le string qui contient le nom du view model
        string nomViewModel = "suikut.ViewModels.Niveaux." + niveau.Libelle + "LevelViewModel, " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        // Obtenir le type du view model à partir du nom
        Type typeViewModel = Type.GetType(nomViewModel);

        // Résoudre le view model à partir du conteneur Splat
        object viewModelObj = Activator.CreateInstance(typeViewModel, args:niveau);

        dynamic viewModel = Convert.ChangeType(viewModelObj, typeViewModel);
        
        ContentViewModel = viewModel;
    }

    public void QuitLevel(object scoreLevelObj)
    {
        Score scoreLevel = (Score)scoreLevelObj;
        SuichukoService.UpdateScore(scoreLevel); // on sauvegarde le score du joueur
        GoLevelMenu(scoreLevel.Niveau);
    }
}