using System;
using System.Collections.Generic;

namespace suikut.Models
{
    public partial class Ambiance
    {
        public Ambiance()
        {
            Musiques = new HashSet<Musique>();
            Niveaus = new HashSet<Niveau>();
        }

        public int Id { get; set; }
        public string? Libelle { get; set; }

        public virtual ICollection<Musique> Musiques { get; set; }
        public virtual ICollection<Niveau> Niveaus { get; set; }
    }
}
