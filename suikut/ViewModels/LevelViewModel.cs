using System;
using System.Collections.Generic;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class LevelViewModel : ViewModelBase
{
    public Niveau niveau { get; set; }
    public Score scoreJoueur { get; set; }
    public IEnumerable<Score> scoresNiveau { get; set; }
    public bool hasMinScore { get; set; }
    public bool hasMidScore { get; set; }
    public bool hasMaxScore { get; set; }
    
    public ISuichukoService SuichukoService { get; set; }
    
    public LevelViewModel(Niveau niveau)
    {
        SuichukoService = new SuichukoService(new SuichukoContext());
        this.niveau = niveau;
        scoresNiveau = SuichukoService.FinScoresByNiveau(niveau);
        scoreJoueur = SuichukoService.FindScore(int.Parse(Environment.GetEnvironmentVariable("USER_ID")), niveau.Id); // on récupère l'ID de l'utilisateur connecté
        hasMinScore = niveau.ScoreMin < scoreJoueur.Score1;
        hasMidScore = niveau.ScoreMid < scoreJoueur.Score1;
        hasMaxScore = niveau.ScoreMax < scoreJoueur.Score1;
    }
}