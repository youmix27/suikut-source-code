using System;
using System.Collections.Generic;

namespace suikut.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string? Pseudo { get; set; }
        public string? HashMdp { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
    }
}
