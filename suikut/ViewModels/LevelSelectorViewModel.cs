using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class LevelSelectorViewModel : ViewModelBase
{
    public IEnumerable<Ambiance> ambiances { get; set; }
    
    public ISuichukoService SuichukoService { get; set; }

    public LevelSelectorViewModel()
    {
        SuichukoService = new SuichukoService(new SuichukoContext());
        ambiances = SuichukoService.FindAllAmbiances();
        foreach (var ambiance in ambiances)
        {
            ambiance.Niveaus = SuichukoService.FindNiveauxByAmbiance(ambiance);
        }
    }
    
}