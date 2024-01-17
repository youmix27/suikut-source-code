using System;
using System.Collections.Generic;

namespace suikut.Models
{
    public partial class Musique
    {
        public int Id { get; set; }
        public string? Libelle { get; set; }
        public string? NomFichier { get; set; }
        public int AmbianceId { get; set; }

        public virtual Ambiance Ambiance { get; set; } = null!;
    }
}
