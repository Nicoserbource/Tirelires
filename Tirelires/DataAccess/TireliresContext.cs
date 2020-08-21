using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tirelires.Data;

namespace Tirelires
{
    public partial class TireliresContext : IdentityContext
    {
        public TireliresContext()
        {
        }

        public TireliresContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avis> Avis { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Commande> Commande { get; set; }
        public virtual DbSet<Couleur> Couleur { get; set; }
        public virtual DbSet<DetailCommande> DetailCommande { get; set; }
        public virtual DbSet<Fabricant> Fabricant { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Produit> Produit { get; set; }
        public virtual DbSet<StatutCommande> StatutCommande { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Tirelires;Integrated Security=True");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Avis>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contenu)
                    .IsRequired()
                    .HasColumnName("contenu")
                    .HasColumnType("ntext");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.IdProduit).HasColumnName("idProduit");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avis_Clients");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.IdProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avis_Produits");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(50);

                entity.Property(e => e.Statut).HasColumnName("statut");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.IdStatut).HasColumnName("idStatut");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Commande)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commandes_Clients");

                entity.HasOne(d => d.IdStatutNavigation)
                    .WithMany(p => p.Commande)
                    .HasForeignKey(d => d.IdStatut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commandes_StatutsCommande");
            });

            modelBuilder.Entity<Couleur>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DetailCommande>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCommande).HasColumnName("idCommande");

                entity.Property(e => e.IdProduit).HasColumnName("idProduit");

                entity.Property(e => e.PrixUnitaire)
                    .HasColumnName("prixUnitaire")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Quantite).HasColumnName("quantite");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.DetailCommande)
                    .HasForeignKey(d => d.IdCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailsCommande_Commandes");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.DetailCommande)
                    .HasForeignKey(d => d.IdProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailsCommande_Produits");
            });

            modelBuilder.Entity<Fabricant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse")
                    .HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chemin)
                    .IsRequired()
                    .HasColumnName("chemin");

                entity.Property(e => e.IdProduit).HasColumnName("idProduit");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.IdProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Images_Produits");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacité).HasColumnName("capacité");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("ntext");

                entity.Property(e => e.Hauteur)
                    .HasColumnName("hauteur")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IdCouleur).HasColumnName("idCouleur");

                entity.Property(e => e.IdFabricant).HasColumnName("idFabricant");

                entity.Property(e => e.IdImage).HasColumnName("idImage");

                entity.Property(e => e.Largeur)
                    .HasColumnName("largeur")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Longueur)
                    .HasColumnName("longueur")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);

                entity.Property(e => e.Poids)
                    .HasColumnName("poids")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Prix)
                    .HasColumnName("prix")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.HasOne(d => d.IdCouleurNavigation)
                    .WithMany(p => p.Produit)
                    .HasForeignKey(d => d.IdCouleur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produits_Couleurs");

                entity.HasOne(d => d.IdFabricantNavigation)
                    .WithMany(p => p.Produit)
                    .HasForeignKey(d => d.IdFabricant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produits_Fabricants");
            });

            modelBuilder.Entity<StatutCommande>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Statut)
                    .IsRequired()
                    .HasColumnName("statut")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
