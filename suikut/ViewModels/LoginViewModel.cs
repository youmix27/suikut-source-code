using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace suikut.ViewModels;

public class LoginViewModel : ViewModelBase
{
    public string Pseudo { get; set; }
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