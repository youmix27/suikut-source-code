using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;
using suikut.Models;
using suikut.Services;
using suikut.ViewModels;
using suikut.ViewModels.Niveaux;
using suikut.Views;

namespace suikut;

public partial class App : Application
{
    public override void Initialize()
    {
        Locator.CurrentMutable.Register(() => new SuichukoService(new SuichukoContext()), typeof(ISuichukoService));
        Locator.CurrentMutable.Register(() => new TutorielleLevelViewModel(), typeof(MainWindowViewModel));
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
                
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}