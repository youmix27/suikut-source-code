using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace suikut.Models
{
    public partial class SuichukoContext : DbContext
    {
        public SuichukoContext()
        {
        }

        public SuichukoContext(DbContextOptions<SuichukoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ambiance> Ambiances { get; set; } = null!;
        public virtual DbSet<Difficulte> Difficultes { get; set; } = null!;
        public virtual DbSet<Musique> Musiques { get; set; } = null!;
        public virtual DbSet<Niveau> Niveaux { get; set; } = null!;
        public virtual DbSet<Score> Scores { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.30.111.32;Database=Suichuko;User Id=Suichoku_user;TrustServerCertificate=true;Password=123+Aze;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ambiance>(entity =>
            {
                entity.ToTable("Ambiance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Libelle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("libelle");
            });

            modelBuilder.Entity<Difficulte>(entity =>
            {
                entity.ToTable("Difficulte");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Libelle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("libelle");
            });

            modelBuilder.Entity<Musique>(entity =>
            {
                entity.ToTable("Musique");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmbianceId).HasColumnName("ambiance_id");

                entity.Property(e => e.Libelle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("libelle");

                entity.Property(e => e.NomFichier)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nom_fichier");

                entity.HasOne(d => d.Ambiance)
                    .WithMany(p => p.Musiques)
                    .HasForeignKey(d => d.AmbianceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Musique__ambianc__3B75D760");
            });

            modelBuilder.Entity<Niveau>(entity =>
            {
                entity.ToTable("Niveau");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmbianceId).HasColumnName("ambiance_id");

                entity.Property(e => e.DifficulteId).HasColumnName("difficulte_id");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Libelle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("libelle");

                entity.Property(e => e.ScoreMax).HasColumnName("scoreMax");

                entity.Property(e => e.ScoreMid).HasColumnName("scoreMid");

                entity.Property(e => e.ScoreMin).HasColumnName("scoreMin");

                entity.HasOne(d => d.Ambiance)
                    .WithMany(p => p.Niveaus)
                    .HasForeignKey(d => d.AmbianceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Niveau__ambiance__3F466844");

                entity.HasOne(d => d.Difficulte)
                    .WithMany(p => p.Niveaus)
                    .HasForeignKey(d => d.DifficulteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Niveau__difficul__3E52440B");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.UtilisateurId, e.NiveauId })
                    .HasName("PK__Score__4D54996B867624D2");

                entity.ToTable("Score");

                entity.Property(e => e.UtilisateurId).HasColumnName("utilisateur_id");

                entity.Property(e => e.NiveauId).HasColumnName("niveau_id");

                entity.Property(e => e.Score1).HasColumnName("score");

                entity.HasOne(d => d.Niveau)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.NiveauId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Score__niveau_id__44FF419A");

                entity.HasOne(d => d.Utilisateur)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Score__utilisate__440B1D61");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("Utilisateur");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.HashMdp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hashMDP");

                entity.Property(e => e.Pseudo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pseudo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
