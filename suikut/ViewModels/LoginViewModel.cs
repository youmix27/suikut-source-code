using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace suikut.ViewModels;

public class LoginViewModel : ViewModelBase
{
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string Pseudo { get; set; }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string MotDePasse { get; set; }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
    }

    public LoginViewModel()
    {
        ErrorMessage = "";
    }
}