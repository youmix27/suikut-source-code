using System;
using System.Collections.Generic;
using ReactiveUI;
using Splat;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels;

public class LevelViewModel : ViewModelBase
{
    public Niveau niveau { get; set; }
    public Difficulte difficulte { get; set; }
    public Score scoreJoueur { get; set; }
    private IEnumerable<Score> _scoresNiveau;
    public IEnumerable<Score> scoresNiveau
    {
        get => _scoresNiveau;
        set => this.RaiseAndSetIfChanged(ref _scoresNiveau, value);
    }
    public bool hasMinScore { get; set; } = false;
    public bool hasMidScore { get; set; } = false;
    public bool hasMaxScore { get; set; } = false;
    public bool isAdmin { get; set; }
    
    private readonly ISuichukoService SuichukoService; 
    
    public LevelViewModel(Niveau niveau)
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
        this.niveau = niveau;
        difficulte = SuichukoService.FindDifficulte(niveau.DifficulteId);
        scoresNiveau = SuichukoService.FinScoresByNiveauOrderByScore(niveau);
        int idJoueur = int.Parse(Environment.GetEnvironmentVariable("USER_ID"));
        scoreJoueur = SuichukoService.FindScore(idJoueur, niveau.Id); // on récupère l'ID de l'utilisateur connecté
        if (scoreJoueur == null)
        {
            scoreJoueur = new Score();
            scoreJoueur.Score1 = 0;
            scoreJoueur.NiveauId = niveau.Id;
            scoreJoueur.UtilisateurId = idJoueur;
            SuichukoService.InsertScore(scoreJoueur);
        }
        
        //on vérifie si les objectifs de score sont atteint
        hasMinScore = niveau.ScoreMin < scoreJoueur.Score1;
        hasMidScore = niveau.ScoreMid < scoreJoueur.Score1;
        hasMaxScore = niveau.ScoreMax < scoreJoueur.Score1;
        
        if (Environment.GetEnvironmentVariable("USER_ROLE") == "Administrator")
        {
            isAdmin = true;
        }
        else
        {
            isAdmin = false;
        }
    }

    /*
     * Supprime le score en paramètre de la méthode puis regénère le tableau des scores
     */
    public void DeleteScore(Score score)
    {
        score.Score1 = 0;
        SuichukoService.UpdateScore(score);
        scoresNiveau = SuichukoService.FinScoresByNiveauOrderByScore(niveau); //on regénère le tableau des scores
    }
}