﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tirelires;

namespace Tirelires.Migrations
{
    [DbContext(typeof(TireliresContext))]
    [Migration("20200818145145_initIdentity")]
    partial class initIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Tirelires.Avis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnName("contenu")
                        .HasColumnType("ntext");

                    b.Property<string>("IdClient")
                        .HasColumnName("idClient")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdProduit")
                        .HasColumnName("idProduit")
                        .HasColumnType("int");

                    b.Property<bool>("Statut")
                        .HasColumnName("statut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdProduit");

                    b.ToTable("Avis");
                });

            modelBuilder.Entity("Tirelires.Client", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnName("prenom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Statut")
                        .HasColumnName("statut")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Tirelires.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<string>("IdClient")
                        .HasColumnName("idClient")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdStatut")
                        .HasColumnName("idStatut")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdStatut");

                    b.ToTable("Commande");
                });

            modelBuilder.Entity("Tirelires.Couleur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Couleur");
                });

            modelBuilder.Entity("Tirelires.DetailCommande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCommande")
                        .HasColumnName("idCommande")
                        .HasColumnType("int");

                    b.Property<int>("IdProduit")
                        .HasColumnName("idProduit")
                        .HasColumnType("int");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnName("prixUnitaire")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("Quantite")
                        .HasColumnName("quantite")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCommande");

                    b.HasIndex("IdProduit");

                    b.ToTable("DetailCommande");
                });

            modelBuilder.Entity("Tirelires.Fabricant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnName("adresse")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Fabricant");
                });

            modelBuilder.Entity("Tirelires.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chemin")
                        .IsRequired()
                        .HasColumnName("chemin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProduit")
                        .HasColumnName("idProduit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProduit");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Tirelires.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacité")
                        .HasColumnName("capacité")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("ntext");

                    b.Property<decimal>("Hauteur")
                        .HasColumnName("hauteur")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("IdCouleur")
                        .HasColumnName("idCouleur")
                        .HasColumnType("int");

                    b.Property<int>("IdFabricant")
                        .HasColumnName("idFabricant")
                        .HasColumnType("int");

                    b.Property<int?>("IdImage")
                        .HasColumnName("idImage")
                        .HasColumnType("int");

                    b.Property<decimal>("Largeur")
                        .HasColumnName("largeur")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("Longueur")
                        .HasColumnName("longueur")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Poids")
                        .HasColumnName("poids")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("Prix")
                        .HasColumnName("prix")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<bool>("Statut")
                        .HasColumnName("statut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCouleur");

                    b.HasIndex("IdFabricant");

                    b.ToTable("Produit");
                });

            modelBuilder.Entity("Tirelires.StatutCommande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnName("statut")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("StatutCommande");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Tirelires.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Tirelires.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tirelires.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Tirelires.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tirelires.Avis", b =>
                {
                    b.HasOne("Tirelires.Client", "IdClientNavigation")
                        .WithMany("Avis")
                        .HasForeignKey("IdClient")
                        .HasConstraintName("FK_Avis_Clients");

                    b.HasOne("Tirelires.Produit", "IdProduitNavigation")
                        .WithMany("Avis")
                        .HasForeignKey("IdProduit")
                        .HasConstraintName("FK_Avis_Produits")
                        .IsRequired();
                });

            modelBuilder.Entity("Tirelires.Commande", b =>
                {
                    b.HasOne("Tirelires.Client", "IdClientNavigation")
                        .WithMany("Commande")
                        .HasForeignKey("IdClient")
                        .HasConstraintName("FK_Commandes_Clients");

                    b.HasOne("Tirelires.StatutCommande", "IdStatutNavigation")
                        .WithMany("Commande")
                        .HasForeignKey("IdStatut")
                        .HasConstraintName("FK_Commandes_StatutsCommande")
                        .IsRequired();
                });

            modelBuilder.Entity("Tirelires.DetailCommande", b =>
                {
                    b.HasOne("Tirelires.Commande", "IdCommandeNavigation")
                        .WithMany("DetailCommande")
                        .HasForeignKey("IdCommande")
                        .HasConstraintName("FK_DetailsCommande_Commandes")
                        .IsRequired();

                    b.HasOne("Tirelires.Produit", "IdProduitNavigation")
                        .WithMany("DetailCommande")
                        .HasForeignKey("IdProduit")
                        .HasConstraintName("FK_DetailsCommande_Produits")
                        .IsRequired();
                });

            modelBuilder.Entity("Tirelires.Image", b =>
                {
                    b.HasOne("Tirelires.Produit", "IdProduitNavigation")
                        .WithMany("Image")
                        .HasForeignKey("IdProduit")
                        .HasConstraintName("FK_Images_Produits")
                        .IsRequired();
                });

            modelBuilder.Entity("Tirelires.Produit", b =>
                {
                    b.HasOne("Tirelires.Couleur", "IdCouleurNavigation")
                        .WithMany("Produit")
                        .HasForeignKey("IdCouleur")
                        .HasConstraintName("FK_Produits_Couleurs")
                        .IsRequired();

                    b.HasOne("Tirelires.Fabricant", "IdFabricantNavigation")
                        .WithMany("Produit")
                        .HasForeignKey("IdFabricant")
                        .HasConstraintName("FK_Produits_Fabricants")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}