using System.Collections.Generic;
using suikut.Models;

namespace suikut.Services;

public interface ISuichukoService
{
    ICollection<Niveau> FindAmbianceNiveaux(Ambiance ambiance);
    Utilisateur FindUtilisateurByPseudo(string pseudo);
    
    IEnumerable<Ambiance> FindAllAmbiances();
    void InsertAmbiance(Ambiance ambiance);
    void UpdateAmbiance(Ambiance ambiance);
    Ambiance? FindAmbiance(long id);
    void DeleteAmbiance(long id);
    
    IEnumerable<Difficulte> FindAllDifficultes();
    void InsertDifficulte(Difficulte difficulte);
    void UpdateDifficulte(Difficulte difficulte);
    Difficulte? FindDifficulte(long id);
    void DeleteDifficulte(long id);
    
    IEnumerable<Musique> FindAllMusiques();
    void InsertMusique(Musique musique);
    void UpdateMusique(Musique musique);
    Musique? FindMusique(long id);
    void DeleteMusique(long id);
    
    IEnumerable<Niveau> FindAllNiveaux();
    void InsertNiveau(Niveau niveau);
    void UpdateNiveau(Niveau niveau);
    Niveau? FindNiveau(long id);
    void DeleteNiveau(long id);
    
    IEnumerable<Score> FindAllScores();
    void InsertScore(Score score);
    void UpdateScore(Score score);
    Score? FindScore(long utilisateurId, long niveauId);
    void DeleteScore(long utilisateurId, long niveauId);
    
    IEnumerable<Utilisateur> FindAllUtilisateurs();
    void InsertUtilisateur(Utilisateur utilisateur);
    void UpdateUtilisateur(Utilisateur utilisateur);
    Utilisateur? FindUtilisateur(long id);
    void DeleteUtilisateur(long id);
}