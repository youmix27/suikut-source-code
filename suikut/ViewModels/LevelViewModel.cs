using System;
using System.Collections.Generic;
using Splat;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class LevelViewModel : ViewModelBase
{
    public Niveau niveau { get; set; }
    public Score scoreJoueur { get; set; } 
    public IEnumerable<Score> scoresNiveau { get; set; } = new List<Score>();
    public bool hasMinScore { get; set; } = false;
    public bool hasMidScore { get; set; } = false;
    public bool hasMaxScore { get; set; } = false;
    
    private readonly ISuichukoService SuichukoService; 
    
    public LevelViewModel(Niveau niveau)
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
        this.niveau = niveau;
        scoresNiveau = SuichukoService.FinScoresByNiveauOrderByScore(niveau);
        scoreJoueur = SuichukoService.FindScore(int.Parse(Environment.GetEnvironmentVariable("USER_ID")), niveau.Id); // on récupère l'ID de l'utilisateur connecté
        if (scoreJoueur == null)
        {
            scoreJoueur = new Score();
            scoreJoueur.Score1 = 0;
        }
        hasMinScore = niveau.ScoreMin < scoreJoueur.Score1;
        hasMidScore = niveau.ScoreMid < scoreJoueur.Score1;
        hasMaxScore = niveau.ScoreMax < scoreJoueur.Score1;
        
    }
}