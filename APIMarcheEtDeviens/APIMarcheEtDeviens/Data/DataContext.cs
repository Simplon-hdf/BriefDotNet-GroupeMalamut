using APIMarcheEtDeviens.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Data
{
    // Classe représentant le contexte de la base de données pour l'application
    public class DataContext : DbContext
    {
        // Définition des ensembles de données (tables) pour chaque modèle
        public DbSet<Media> Media { get; set; } // Table pour les médias
        public DbSet<Participant> Participer { get; set; } // Table pour les participants
        public DbSet<Randonnee> Randonnee { get; set; } // Table pour les randonnées
        public DbSet<Randonneur> Randonneur { get; set; } // Table pour les randonneurs
        public DbSet<Role> Role { get; set; } // Table pour les rôles
        public DbSet<Pensee> Pensee { get; set; } // Table pour les pensées

        // Constructeur prenant les options du contexte de la base de données en paramètre
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // Méthode pour configurer les options du contexte de la base de données
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }
    }
}