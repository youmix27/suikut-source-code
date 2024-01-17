using System;
using System.Collections.Generic;

namespace suikut.Models
{
    public partial class Score
    {
        public int UtilisateurId { get; set; }
        public int NiveauId { get; set; }
        public int? Score1 { get; set; }

        public virtual Niveau Niveau { get; set; } = null!;
        public virtual Utilisateur Utilisateur { get; set; } = null!;
    }
}
