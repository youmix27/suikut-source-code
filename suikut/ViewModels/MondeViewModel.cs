using System.Collections.Generic;
using suikut.Models;

namespace suikut.ViewModels;

public class MondeViewModel : ViewModelBase
{
    private readonly Ambiance ambiance;

    public MondeViewModel(Ambiance ambiance)
    {
        this.ambiance = ambiance;
    }

    public string Libelle => ambiance.Libelle;

    public ICollection<Niveau> Niveaux => ambiance.Niveaus;

}