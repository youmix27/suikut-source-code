using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using suikut.Models;
using suikut.Services;

namespace suikut.Services;

public class SuichukoService : ISuichukoService
{
    private SuichukoContext _context;
    public SuichukoService(SuichukoContext context)
    {
        _context = context;
    }

/*
 *
 *------------------------------------------------------
 * Service d'accès à la Base de Données Suichuko
 *------------------------------------------------------
 * 
 */

#region Ambiance

    /*
     * 
     *  Méthode lié à la table AMBIANCE
     * 
     */
    
    
    
    public void DeleteAmbiance(int id)
    {
        try
        {
            Ambiance ord = _context.Ambiances.Find(id);
            _context.Ambiances.Remove(ord);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public IEnumerable<Ambiance> FindAllAmbiances()
    {
        try
        {
            return _context.Ambiances.Include(a => a.Niveaus).ToList();
        }
        catch
        {
            throw;
        }
    }

    public void InsertAmbiance(Ambiance ambiance)
    {
        try
        {
            _context.Ambiances.Add(ambiance);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public Ambiance? FindAmbiance(int id)
    {
        try
        {
            return _context.Ambiances.Find(id);
        }
        catch
        {
            throw;
        }
    }

    public void UpdateAmbiance(Ambiance ambiance)
    {
        try
        {
            var local = _context.Set<Ambiance>().Local.FirstOrDefault(entry => entry.Id.Equals(ambiance.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(ambiance).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
    #endregion

#region Difficulté

    /*
     *
     *  Méthode lié à la table AMBIANCE
     *
     */

    public void DeleteDifficulte(int id)
    {
        try
        {
            Difficulte ord = _context.Difficultes.Find(id);
            _context.Difficultes.Remove(ord);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public IEnumerable<Difficulte> FindAllDifficultes()
    {
        try
        {
            return _context.Difficultes.ToList();
        }
        catch
        {
            throw;
        }
    }

    public void InsertDifficulte(Difficulte difficulte)
    {
        try
        {
            _context.Difficultes.Add(difficulte);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public Difficulte? FindDifficulte(int id)
    {
        try
        {
            return _context.Difficultes.Find(id);
        }
        catch
        {
            throw;
        }
    }

    public void UpdateDifficulte(Difficulte difficulte)
    {
        try
        {
            var local = _context.Set<Difficulte>().Local.FirstOrDefault(entry => entry.Id.Equals(difficulte.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(difficulte).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
#endregion

#region Musique
    
    public void DeleteMusique(int id)
    {
        try
        {
            Musique ord = _context.Musiques.Find(id);
            _context.Musiques.Remove(ord);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public IEnumerable<Musique> FindAllMusiques()
    {
        try
        {
            return _context.Musiques.ToList();
        }
        catch
        {
            throw;
        }
    }

    public void InsertMusique(Musique musique)
    {
        try
        {
            _context.Musiques.Add(musique);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public Musique? FindMusique(int id)
    {
        try
        {
            return _context.Musiques.Find(id);
        }
        catch
        {
            throw;
        }
    }

    public void UpdateMusique(Musique musique)
    {
        try
        {
            var local = _context.Set<Musique>().Local.FirstOrDefault(entry => entry.Id.Equals(musique.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(musique).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
#endregion    

#region Niveau

    public ICollection<Niveau> FindNiveauxByAmbiance(Ambiance ambiance)
    {
        ICollection<Niveau> niveaux = _context.Niveaux.Where(n => n.Ambiance == ambiance).ToList();
        return niveaux;
    }

    
    
    public void DeleteNiveau(int id)
    {
        try
        {
            Niveau ord = _context.Niveaux.Find(id);
            _context.Niveaux.Remove(ord);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public IEnumerable<Niveau> FindAllNiveaux()
    {
        try
        {
            return _context.Niveaux.ToList();
        }
        catch
        {
            throw;
        }
    }

    public void InsertNiveau(Niveau niveau)
    {
        try
        {
            _context.Niveaux.Add(niveau);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public Niveau? FindNiveau(int id)
    {
        try
        {
            return _context.Niveaux.Find(id);
        }
        catch
        {
            throw;
        }
    }

    public void UpdateNiveau(Niveau niveau)
    {
        try
        {
            var local = _context.Set<Niveau>().Local.FirstOrDefault(entry => entry.Id.Equals(niveau.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(niveau).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
#endregion

#region Score

    public IEnumerable<Score> FinScoresByNiveauOrderByScore(Niveau niveau)
    {
        IEnumerable<Score> scores = _context.Scores.Include(s => s.Utilisateur).Where(s => s.Niveau == niveau).OrderByDescending(s => s.Score1).ToList();
        return scores;
    }
    public void DeleteScore(int utilisateurId, int niveauId)
    {
        try
        {
            Score ord = _context.Scores.Find(utilisateurId, niveauId);
            _context.Scores.Remove(ord);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public IEnumerable<Score> FindAllScores()
    {
        try
        {
            return _context.Scores.ToList();
        }
        catch
        {
            throw;
        }
    }

    public void InsertScore(Score score)
    {
        try
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public Score? FindScore(int utilisateurId, int niveauId)
    {
        try
        {
            return _context.Scores.Find(utilisateurId, niveauId);
        }
        catch
        {
            throw;
        }
    }

    public void UpdateScore(Score score)
    {
        try
        {
            var local = _context.Set<Score>().Local.FirstOrDefault(entry => entry.UtilisateurId.Equals(score.UtilisateurId) && entry.NiveauId.Equals(score.NiveauId));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(score).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
#endregion

#region Utilisateur

    public Utilisateur FindUtilisateurByPseudo(string pseudo)
    {

        Utilisateur utilisateur = _context.Utilisateurs.Where(u => u.Pseudo == pseudo).FirstOrDefault();

        return utilisateur;
    }
    
    public void DeleteUtilisateur(int id)
    {
        try
        {
            Utilisateur ord = _context.Utilisateurs.Find(id);
            _context.Utilisateurs.Remove(ord);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
    public IEnumerable<Utilisateur> FindAllUtilisateurs()
    {
        try
        {
            return _context.Utilisateurs.ToList();
        }
        catch
        {
            throw;
        }
    }

    public void InsertUtilisateur(Utilisateur utilisateur)
    {
        try
        {
            _context.Utilisateurs.Add(utilisateur);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public Utilisateur? FindUtilisateur(int id)
    {
        try
        {
            return _context.Utilisateurs.Find(id);
        }
        catch
        {
            throw;
        }
    }

    public void UpdateUtilisateur(Utilisateur utilisateur)
    {
        try
        {
            var local = _context.Set<Utilisateur>().Local.FirstOrDefault(entry => entry.Id.Equals(utilisateur.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(utilisateur).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
#endregion    
    
}