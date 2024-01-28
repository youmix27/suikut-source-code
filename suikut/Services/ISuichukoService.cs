using System.Collections.Generic;
using suikut.Models;

namespace suikut.Services;

public interface ISuichukoService
{
    ICollection<Score> FinScoresByNiveau(Niveau niveau);
    ICollection<Niveau> FindNiveauxByAmbiance(Ambiance ambiance);
    Utilisateur FindUtilisateurByPseudo(string pseudo);
    
    IEnumerable<Ambiance> FindAllAmbiances();
    void InsertAmbiance(Ambiance ambiance);
    void UpdateAmbiance(Ambiance ambiance);
    Ambiance? FindAmbiance(int id);
    void DeleteAmbiance(int id);
    
    IEnumerable<Difficulte> FindAllDifficultes();
    void InsertDifficulte(Difficulte difficulte);
    void UpdateDifficulte(Difficulte difficulte);
    Difficulte? FindDifficulte(int id);
    void DeleteDifficulte(int id);
    
    IEnumerable<Musique> FindAllMusiques();
    void InsertMusique(Musique musique);
    void UpdateMusique(Musique musique);
    Musique? FindMusique(int id);
    void DeleteMusique(int id);
    
    IEnumerable<Niveau> FindAllNiveaux();
    void InsertNiveau(Niveau niveau);
    void UpdateNiveau(Niveau niveau);
    Niveau? FindNiveau(int id);
    void DeleteNiveau(int id);
    
    IEnumerable<Score> FindAllScores();
    void InsertScore(Score score);
    void UpdateScore(Score score);
    Score? FindScore(int utilisateurId, int niveauId);
    void DeleteScore(int utilisateurId, int niveauId);
    
    IEnumerable<Utilisateur> FindAllUtilisateurs();
    void InsertUtilisateur(Utilisateur utilisateur);
    void UpdateUtilisateur(Utilisateur utilisateur);
    Utilisateur? FindUtilisateur(int id);
    void DeleteUtilisateur(int id);
}