using suikut.Models;

namespace suikut.ViewModels;
using ReactiveUI;
using System.Reactive;

public class RegisterViewModel : ViewModelBase
{
    private string _description = string.Empty;

        public ReactiveCommand<Unit, Utilisateur> RegisterCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        
        public RegisterViewModel()
        {
        }

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }
}