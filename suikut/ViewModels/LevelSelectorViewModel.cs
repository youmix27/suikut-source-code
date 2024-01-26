using System.Collections.Generic;
using System.Collections.ObjectModel;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class LevelSelectorViewModel : ViewModelBase
{
    public IEnumerable<Ambiance> ambiances { get; set; }
    
    public ObservableCollection<MondeViewModel> MondeSelectable { get; } = new();
    public ISuichukoService SuichukoService { get; set; }

    public LevelSelectorViewModel()
    {
        SuichukoService = new SuichukoService(new SuichukoContext());
        ambiances = SuichukoService.FindAllAmbiances();
        foreach (Ambiance ambiance in ambiances)
        {
            MondeSelectable.Add(new MondeViewModel(ambiance));
        }
    }
}