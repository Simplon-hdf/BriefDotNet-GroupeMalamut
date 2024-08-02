using APIMarcheEtDeviens.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Media> Medias { get; set; }
		public DbSet<Participer> Participers { get; set; }
		public DbSet<Randonnee> Randonnees { get; set; }
		public DbSet<Randonneur> Randonneurs { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Pensee> Pensees { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{

		}
	}
}
