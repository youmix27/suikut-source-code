using System.Collections.Generic;
using ReactiveUI;
using Splat;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class UserViewModel : ViewModelBase
{
    private readonly ISuichukoService SuichukoService;
    private IEnumerable<Utilisateur> _utilisateursNonAdmin;
    public IEnumerable<Utilisateur> utilisateursNonAdmin
    {
        get => _utilisateursNonAdmin;
        set => this.RaiseAndSetIfChanged(ref _utilisateursNonAdmin, value);
    }
    
    public UserViewModel()
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
        utilisateursNonAdmin = SuichukoService.FindAllUtilisateursNonAdmin();
    }

    /*
     * Banni l'utilisateur passé en paramètre
     */
    public void Ban(Utilisateur utilisateur)
    {
        utilisateur.IsBanned = true;
        SuichukoService.UpdateUtilisateur(utilisateur);
        utilisateursNonAdmin = SuichukoService.FindAllUtilisateursNonAdmin();
    }

    /*
     * Débanni l'utilisateur passé en paramètre
     */
    public void Unban(Utilisateur utilisateur)
    {
        utilisateur.IsBanned = false;
        SuichukoService.UpdateUtilisateur(utilisateur);
        utilisateursNonAdmin = SuichukoService.FindAllUtilisateursNonAdmin();
    }
}