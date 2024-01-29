using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Splat;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class LevelSelectorViewModel : ViewModelBase
{
    public IEnumerable<Ambiance> ambiances { get; set; }

    private readonly ISuichukoService SuichukoService; 

    public LevelSelectorViewModel()
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
        ambiances = SuichukoService.FindAllAmbiances();
    }
    
}