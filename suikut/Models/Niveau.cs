using System;
using System.Collections.Generic;

namespace suikut.Models
{
    public partial class Niveau
    {
        public Niveau()
        {
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string? Libelle { get; set; }
        public int DifficulteId { get; set; }
        public int AmbianceId { get; set; }
        public string? Image { get; set; }
        public int? ScoreMin { get; set; }
        public int? ScoreMid { get; set; }
        public int? ScoreMax { get; set; }

        public virtual Ambiance Ambiance { get; set; } = null!;
        public virtual Difficulte Difficulte { get; set; } = null!;
        public virtual ICollection<Score> Scores { get; set; }
    }
}
