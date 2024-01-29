using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using Splat;
using suikut.Models;
using suikut.Services;

namespace suikut.Views;

public partial class LoginView : UserControl
{
    private readonly ISuichukoService SuichukoService;
    
    public LoginView()
    {
        SuichukoService =  Locator.Current.GetService<ISuichukoService>();
        InitializeComponent();
    }
    
    public void Login(object source, RoutedEventArgs args)
    {
        Utilisateur utilisateur = SuichukoService.FindUtilisateurByPseudo(TextBoxPseudo.Text);
        if (utilisateur == null || !BCrypt.Net.BCrypt.Verify(TextBoxMdp.Text, utilisateur.HashMdp))
        {
            TextBlockErreur.IsVisible = true;
            return;
        }
        var mainMenu = new MainMenuView();
        // On sauvegarde les inforamtions utilies sur l'utilisateur connecté dans nos variables d'environnement
        Environment.SetEnvironmentVariable("USER_PSEUDO", utilisateur.Pseudo);
        Environment.SetEnvironmentVariable("USER_ID", utilisateur.Id.ToString());
        this.Content = mainMenu;
    }
}