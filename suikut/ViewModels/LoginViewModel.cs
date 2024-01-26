using System.ComponentModel.DataAnnotations;

namespace suikut.ViewModels;

public class LoginViewModel : ViewModelBase
{
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string Pseudo { get; set; }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string MotDePasse { get; set; }
}