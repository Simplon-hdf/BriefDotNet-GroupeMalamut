﻿// <auto-generated />
using System;
using APIMarcheEtDeviens.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIMarcheEtDeviens.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Media", b =>
                {
                    b.Property<string>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("CheminDuMedia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomMedia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RandonneeId")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("TypeMedia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MediaId");

                    b.HasIndex("RandonneeId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Participer", b =>
                {
                    b.Property<int>("ParticiperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RandonneeId")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("RandonneurId")
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("ParticiperId");

                    b.HasIndex("RandonneeId");

                    b.HasIndex("RandonneurId");

                    b.ToTable("Participer");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Pensee", b =>
                {
                    b.Property<string>("PenseeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ContenuPensee")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MediaId")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("NomDeLaPensee")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PenseeId");

                    b.HasIndex("MediaId");

                    b.ToTable("Pensee");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Randonnee", b =>
                {
                    b.Property<string>("RandonneeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<int>("NombreMaxPersonnes")
                        .HasColumnType("int");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("PrixTotal")
                        .HasColumnType("float");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RandonneeId");

                    b.ToTable("Randonnee");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Randonneur", b =>
                {
                    b.Property<string>("RandonneurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RandonneurId");

                    b.HasIndex("RoleId");

                    b.ToTable("Randonneur");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Media", b =>
                {
                    b.HasOne("APIMarcheEtDeviens.Models.Randonnee", "Randonnee")
                        .WithMany("Medias")
                        .HasForeignKey("RandonneeId");

                    b.Navigation("Randonnee");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Participer", b =>
                {
                    b.HasOne("APIMarcheEtDeviens.Models.Randonnee", "Randonnee")
                        .WithMany("Participers")
                        .HasForeignKey("RandonneeId");

                    b.HasOne("APIMarcheEtDeviens.Models.Randonneur", "Randonneur")
                        .WithMany("Participers")
                        .HasForeignKey("RandonneurId");

                    b.Navigation("Randonnee");

                    b.Navigation("Randonneur");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Pensee", b =>
                {
                    b.HasOne("APIMarcheEtDeviens.Models.Media", "Media")
                        .WithMany("Pensees")
                        .HasForeignKey("MediaId");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Randonneur", b =>
                {
                    b.HasOne("APIMarcheEtDeviens.Models.Role", "Role")
                        .WithMany("Randonneurs")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Media", b =>
                {
                    b.Navigation("Pensees");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Randonnee", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("Participers");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Randonneur", b =>
                {
                    b.Navigation("Participers");
                });

            modelBuilder.Entity("APIMarcheEtDeviens.Models.Role", b =>
                {
                    b.Navigation("Randonneurs");
                });
#pragma warning restore 612, 618
        }
    }
}