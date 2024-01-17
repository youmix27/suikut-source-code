using System;
using System.Collections.Generic;

namespace suikut.Models
{
    public partial class Difficulte
    {
        public Difficulte()
        {
            Niveaus = new HashSet<Niveau>();
        }

        public int Id { get; set; }
        public string? Libelle { get; set; }

        public virtual ICollection<Niveau> Niveaus { get; set; }
    }
}
