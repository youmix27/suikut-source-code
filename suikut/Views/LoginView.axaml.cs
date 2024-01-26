using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using suikut.Models;
using suikut.Services;

namespace suikut.Views;

public partial class LoginView : UserControl
{
    private ISuichukoService service;
    
    public LoginView()
    {
        service =  new SuichukoService(new SuichukoContext());
        InitializeComponent();
    }
    
    public void Login(object source, RoutedEventArgs args)
    {
        Utilisateur utilisateur = service.FindUtilisateurByPseudo(TextBoxPseudo.Text);
        if (utilisateur == null || !BCrypt.Net.BCrypt.Verify(TextBoxMdp.Text, utilisateur.HashMdp))
        {
            TextBlockErreur.IsVisible = true;
            return;
        }
        var mainMenu = new MainMenuView();
        this.Content = mainMenu;
    }
}