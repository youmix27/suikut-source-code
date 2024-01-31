using System;
using ReactiveUI;
using Splat;
using suikut.Models;
using suikut.Services;

namespace suikut.ViewModels.Niveaux;

public class TestLevelViewModel : ViewModelBase
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
    
    public TestLevelViewModel(Niveau niveau)
    {
        SuichukoService = Locator.Current.GetService<ISuichukoService>();
        scoreJoueur = SuichukoService.FindScore(int.Parse(Environment.GetEnvironmentVariable("USER_ID")), niveau.Id); // on récupère l'ID de l'utilisateur connecté
        this.niveau = niveau;
        scoreActuel = (int)scoreJoueur.Score1;
    }

    public void Add()
    {
        scoreActuel += 1;
        scoreJoueur.Score1 += 1;
    }
}