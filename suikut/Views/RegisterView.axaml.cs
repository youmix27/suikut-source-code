using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using suikut.Models;
using suikut.Services;

namespace suikut.Views;

public partial class RegisterView : UserControl
{
    
    private ISuichukoService service;
    
    public RegisterView()
    {
        service =  new SuichukoService(new SuichukoContext());
        InitializeComponent();
    }

    public void Register(object source, RoutedEventArgs args)
    {
        Utilisateur utilisateur = new Utilisateur();
        utilisateur.Email = TextBoxEmail.Text;
        utilisateur.Pseudo = TextBoxPseudo.Text;
        utilisateur.HashMdp = BCrypt.Net.BCrypt.HashPassword(TextBoxPassword1.Text);
        service.InsertUtilisateur(utilisateur);
        var loginView = new LoginView();
        this.Content = loginView;
    }
}