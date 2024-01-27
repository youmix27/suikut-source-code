using System;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class LevelViewModel : ViewModelBase
{
    public Niveau niveau { get; set; }
    public Score scoreJoueur { get; set; }
    
    public ISuichukoService SuichukoService { get; set; }
    
    public LevelViewModel(Niveau niveau)
    {
        SuichukoService = new SuichukoService(new SuichukoContext());
        this.niveau = niveau;
        scoreJoueur = SuichukoService.FindScore(Int32.Parse(Environment.GetEnvironmentVariable("USER_ID")), niveau.Id); // on récupère l'ID de l'utilisateur connecté
    }
}