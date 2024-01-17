using suikut.Services;
using ReactiveUI;

namespace suikut.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel()
    {
        var service = new ToDoListService();
        Login = new LoginViewModel();
        _contentViewModel = Login;
    }

    public LoginViewModel Login { get; }
    
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void Register()
    {
        ContentViewModel = new RegisterViewModel();
    }
    public void RegisterCancel()
    {
        ContentViewModel = new LoginViewModel();
    }
}