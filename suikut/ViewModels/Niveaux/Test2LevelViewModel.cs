using System;
using System.Linq;
using ReactiveUI;
using Splat;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels.Niveaux;

public class Test2LevelViewModel : ViewModelBase
{
    private readonly ISuichukoService SuichukoService;

    public Score scoreJoueur { get; set; }

    private int _scoreActuel; // variable là pour permettre l'affichage en directe du score utilisateur
    public int scoreActuel
    {
        get => _scoreActuel;
        set => this.RaiseAndSetIfChanged(ref _scoreActuel, value);
    }

    public Niveau niveau { get; set; }
    public Ambiance ambiance { get; set; }
    public Musique musique { get; set; }
    
    public Test2LevelViewModel(Niveau niveau)
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
        scoreJoueur = SuichukoService.FindScore(int.Parse(Environment.GetEnvironmentVariable("USER_ID")), niveau.Id); // on récupère l'ID de l'utilisateur connecté
        this.niveau = niveau;
        ambiance = SuichukoService.FindAmbiance(niveau.AmbianceId);
        musique = ambiance.Musiques.FirstOrDefault();
        scoreActuel = (int)scoreJoueur.Score1;
    }

    public void Add()
    {
        scoreActuel += 1;
        scoreJoueur.Score1 += 1;
    }
}