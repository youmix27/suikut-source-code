using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Avalonia.Data;

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
        
        public bool IsAdmin { get; set; }
        
        public bool IsBanned { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
    }
}
