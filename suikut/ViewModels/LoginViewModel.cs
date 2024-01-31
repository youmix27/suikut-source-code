using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace suikut.ViewModels;

public class LoginViewModel : ViewModelBase
{
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string Pseudo { get; set; }
    [Required(ErrorMessage = "ce champ est nécessaire")]
    public string MotDePasse { get; set; }

    private bool _IsInvalid;
    public bool IsInvalid
    {
        get => _IsInvalid;
        set => this.RaiseAndSetIfChanged(ref _IsInvalid, value);
    }

    public LoginViewModel()
    {
        IsInvalid = false;
    }
}