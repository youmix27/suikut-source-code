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
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string Pseudo { get; set; }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    [MinLength(8, ErrorMessage = "le mot de passe doit faire 8 char minimum")]
    public string MotDePasse { get; set; }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    [EmailAddress(ErrorMessage = "email invalide")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    [Compare("MotDePasse", ErrorMessage = "différent de l'autre mot de passe")]
    public string MotDePasseConfirme { get; set; }

    public RegisterViewModel()
    {
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