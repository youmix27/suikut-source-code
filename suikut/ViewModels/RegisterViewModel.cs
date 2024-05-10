using System.ComponentModel.DataAnnotations;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;
using ReactiveUI;
using System.Reactive;

public class RegisterViewModel : ViewModelBase
{
    private string? _pseudo;
    private string? _motDePasse;
    private string? _motDePasseConfirme;
    private string? _email;

    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string? Pseudo
    {
        get { return _pseudo; }
        set { this.RaiseAndSetIfChanged(ref _pseudo, value);  }
    }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    [MinLength(8, ErrorMessage = "le mot de passe doit faire 8 char minimum")]
    public string? MotDePasse
    {
        get { return _motDePasse; }
        set { this.RaiseAndSetIfChanged(ref _motDePasse, value);  }
    }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    [EmailAddress(ErrorMessage = "email invalide")]
    public string? Email 
    {
        get { return _email; }
        set { this.RaiseAndSetIfChanged(ref _email, value);  }
    }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string? MotDePasseConfirme
    {
        get { return _motDePasseConfirme; }
        set { this.RaiseAndSetIfChanged(ref _motDePasseConfirme, value);  }
    }
    
    private string _errorMessage;
    public string errorMessage
    {
        get => _errorMessage;
        set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
    }

    public RegisterViewModel()
    {
        _errorMessage = "";
    }

    public void Register()
    {
        ISuichukoService service =  new SuichukoService(new SuichukoContext());
        Utilisateur utilisateur = new Utilisateur();
        utilisateur.Email = Email;
        utilisateur.HashMdp = BCrypt.Net.BCrypt.HashPassword(MotDePasse);
        utilisateur.Pseudo = Pseudo;
        service.InsertUtilisateur(utilisateur);
        
    }
}